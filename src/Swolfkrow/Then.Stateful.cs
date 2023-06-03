namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Continues an existing asynchronous workflow with an asynchronous workflow created by a factory that takes a state folded from the yielded events. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes a state folded from all events yielded by the given asynchronous <paramref name="workflow"/> and returns an asynchronous workflow that is to be executed as continuation.</param>
    /// <param name="computeNextState">A folder that computes a next state based on a previous state and an event.</param>
    /// <param name="initialState">An initial state.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflows.</typeparam>
    /// <typeparam name="TState">The type of the state.</typeparam>
    /// <returns>An asynchronous workflow composed of the given asynchronous <paramref name="workflow"/>, followed by an asynchronous workflow created from a state computed from its yielded events.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent, TState>(this IAsyncEnumerable<TEvent> workflow,
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, TState> computeNextState,
        TState initialState)
    {
        TState currentState = initialState;

        return workflow
            .WithSideEffect(nextEvent => currentState = computeNextState(currentState, nextEvent))
            .Then(() => createContinuation(currentState));
    }
}
