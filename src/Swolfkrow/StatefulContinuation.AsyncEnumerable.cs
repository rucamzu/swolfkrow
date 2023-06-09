namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Continues an asynchronous workflow with an asynchronous workflow factory that takes a state folded from the yielded events. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes a <typeparamref name="TState"/> and returns an asynchronous workflow.</param>
    /// <param name="computeNextState">A folder that takes a previous <typeparamref name="TState"/> and an <typeparamref name="TEvent"/> and returns a next <typeparamref name="TState"/>.</param>
    /// <param name="initialState">An initial <typeparamref name="TState"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <typeparam name="TState">The type of the folded state.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the state computed by the given <paramref name="computeNextState"/> folder.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent, TState>(this IAsyncEnumerable<TEvent> workflow,
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, TState> computeNextState,
        TState initialState)
    {
        TState currentState = initialState;

        void UpdateCurrentState(TEvent nextEvent)
            => currentState = computeNextState(currentState, nextEvent);

        return workflow
            .WithSideEffect(UpdateCurrentState)
            .Then(() => createContinuation(currentState));
    }

    /// <summary>
    /// Continues an asynchronous workflow with an asynchronous workflow factory that takes a state folded from the yielded events. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes a <typeparamref name="TState"/> and returns an asynchronous workflow.</param>
    /// <param name="computeNextState">An asynchronous folder that takes a previous <typeparamref name="TState"/> and an <typeparamref name="TEvent"/> and returns a next <typeparamref name="TState"/>.</param>
    /// <param name="initialState">An initial <typeparamref name="TState"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <typeparam name="TState">The type of the folded state.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the asynchronous workflow returned by awaiting the task returned by calling the given <paramref name="createContinuation"/> factory with the state computed by the given <paramref name="computeNextState"/> folder.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent, TState>(this IAsyncEnumerable<TEvent> workflow,
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, Task<TState>> computeNextState,
        TState initialState)
    {
        TState currentState = initialState;

        async Task UpdateCurrentState(TEvent nextEvent)
            => currentState = await computeNextState(currentState, nextEvent);

        return workflow
            .WithSideEffect(UpdateCurrentState)
            .Then(() => createContinuation(currentState));
    }

    /// <summary>
    /// Continues an asynchronous workflow with an asynchronous workflow factory that takes a state folded from the yielded events. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes a <typeparamref name="TState"/> and returns an asynchronous workflow.</param>
    /// <param name="computeNextState">An asynchronous folder that takes a previous <typeparamref name="TState"/> and an <typeparamref name="TEvent"/> and returns a next <typeparamref name="TState"/>.</param>
    /// <param name="initialState">An initial <typeparamref name="TState"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <typeparam name="TState">The type of the folded state.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the asynchronous workflow returned by awaiting the task returned by calling the given <paramref name="createContinuation"/> factory with the state computed by the given <paramref name="computeNextState"/> folder.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent, TState>(this IAsyncEnumerable<TEvent> workflow,
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, ValueTask<TState>> computeNextState,
        TState initialState)
    {
        TState currentState = initialState;

        async ValueTask UpdateCurrentState(TEvent nextEvent)
            => currentState = await computeNextState(currentState, nextEvent);

        return workflow
            .WithSideEffect(UpdateCurrentState)
            .Then(() => createContinuation(currentState));
    }
}
