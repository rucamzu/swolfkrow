using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with an asynchronous workflow factory that takes a state folded from the yielded events. 
    /// </summary>
    /// <param name="createContinuation">A factory that takes a <typeparamref name="TState"/> and returns an asynchronous workflow.</param>
    /// <param name="computeNextState">A folder that takes a previous <typeparamref name="TState"/> and an <typeparamref name="TEvent"/> and returns a next <typeparamref name="TState"/>.</param>
    /// <param name="initialState">An initial <typeparamref name="TState"/>.</param>
    /// <typeparam name="TState">The type of the folded state.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the state computed by the given <paramref name="computeNextState"/> folder.</returns>
    public Workflow<TEvent> Then<TState>(
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, TState> computeNextState,
        TState initialState)
        => WorkflowImpl
            .ThenWithStateFromFactory(_workflow, createContinuation, computeNextState, initialState)
            .ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with an asynchronous workflow factory that takes a state folded from the yielded events. 
    /// </summary>
    /// <param name="createContinuation">A factory that takes a <typeparamref name="TState"/> and returns an asynchronous workflow.</param>
    /// <param name="computeNextState">An asynchronous folder that takes a previous <typeparamref name="TState"/> and an <typeparamref name="TEvent"/> and returns a next <typeparamref name="TState"/>.</param>
    /// <param name="initialState">An initial <typeparamref name="TState"/>.</param>
    /// <typeparam name="TState">The type of the folded state.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the state computed by the given <paramref name="computeNextState"/> folder.</returns>
    public Workflow<TEvent> Then<TState>(
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, Task<TState>> computeNextState,
        TState initialState)
        => WorkflowImpl
            .ThenWithStateFromTaskFactory(_workflow, createContinuation, computeNextState, initialState)
            .ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with an asynchronous workflow factory that takes a state folded from the yielded events. 
    /// </summary>
    /// <param name="createContinuation">A factory that takes a <typeparamref name="TState"/> and returns an asynchronous workflow.</param>
    /// <param name="computeNextState">An asynchronous folder that takes a previous <typeparamref name="TState"/> and an <typeparamref name="TEvent"/> and returns a next <typeparamref name="TState"/>.</param>
    /// <param name="initialState">An initial <typeparamref name="TState"/>.</param>
    /// <typeparam name="TState">The type of the folded state.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the state computed by the given <paramref name="computeNextState"/> folder.</returns>
    public Workflow<TEvent> Then<TState>(
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, ValueTask<TState>> computeNextState,
        TState initialState)
        => WorkflowImpl
            .ThenWithStateFromValueTaskFactory(_workflow, createContinuation, computeNextState, initialState)
            .ToWorkflow();
}
