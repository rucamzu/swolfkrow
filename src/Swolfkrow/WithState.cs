namespace Swolfkrow;

/// <summary>
/// Factory methods and extension methods to compose asynchronous workflows based on <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static partial class Workflow
{
    /// <summary>
    /// Injects a computed state into an asynchronous workflow that is updated based on each yielded event.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="stateFolder">A state folder function that computes the new state based on the previous state and the next yielded event.</param>
    /// <param name="initialState">The initial state before any events have been yielded.</param>
    /// <typeparam name="TState">The type of the injected state.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the given asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref="workflow"/> and internally computes an updated state based on them.</returns>
    /// <remarks>
    /// Injected state can subsequently be used to chain asynchronous workflow continuations based on it.
    /// </remarks>
    public static IAsyncEnumerable<TEvent> WithState<TState, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TState, TEvent, TState> stateFolder, TState initialState)
        => new StatefulWorkflow<TState, TEvent>(workflow, stateFolder, initialState);

    /// <summary>
    /// Chains an existing stateful asynchronous workflow to the asynchronous workflow created by a factory function that takes an argument based on the computed state. 
    /// </summary>
    /// <param name="workflow">An existing stateful asynchronous workflow.</param>
    /// <param name="createContinuation">A factory function that takes one argument and returns an asynchronous workflow that is to be executed as continuation to the given <paramref name="workflow"/>.</param>
    /// <param name="argSelector">A function that computes the argument passed to the given <paramref name="createContinuation"/> factory function based on the computed state.</param>
    /// <typeparam name="TState">The type of the injected state.</typeparam>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createContinuation"/> factory function.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by both chained asynchronous workflows.</typeparam>
    /// <returns>An asynchronous workflow composed of the given stateful asynchronous <paramref name="workflow"/>, followed by an asynchronous workflow that calls the given <paramref name="createContinuation"/> factory function with an argument computed by the given <paramref name="argSelector"/> function.</returns>
    public static IAsyncEnumerable<TEvent> Then<TState, TArg, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg, IAsyncEnumerable<TEvent>> createContinuation, Func<TState, TArg> argSelector)
    {
        if (workflow is not StatefulWorkflow<TState, TEvent> statefulWorkflow)
            throw new InvalidOperationException("Stateful continuations are only supported on stateful workflows");

        return workflow.Then(() => createContinuation(argSelector(statefulWorkflow.State)));
    }
}

/// <summary>
/// A stateful asynchronous workflow.
/// </summary>
/// <typeparam name="TState">The type of the state held by the stateful asynchronous workflow.</typeparam>
/// <typeparam name="TEvent">The (base) type of the events yielded by the stateful asynchronous workflow.</typeparam>
/// <remarks>
/// Stateful asynchronous workflows keep a computed state based on the previous state and each yielded event.
/// </remarks>
internal class StatefulWorkflow<TState, TEvent> : IAsyncEnumerable<TEvent>
{
    public TState State { get; private set; }

    private IAsyncEnumerable<TEvent> Workflow { get; }

    public StatefulWorkflow(
        IAsyncEnumerable<TEvent> workflow, Func<TState, TEvent, TState> stateFolder, TState initialState)
    {
        State = initialState;    

        Workflow = workflow
            .WithSideEffect(nextEvent => {
                State = stateFolder(State, nextEvent); 
            });
    }

    public IAsyncEnumerator<TEvent> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => Workflow.GetAsyncEnumerator(cancellationToken);
}
