using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with a task. 
    /// </summary>
    /// <param name="continuation">A task that returns an <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the event returned by awaiting the given <paramref name="continuation"/> task.</returns>
    public Workflow<TEvent> Then(
        ValueTask<TEvent> continuation)
        => WorkflowImpl.ThenFromValueTask(_workflow, continuation).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with a task factory. 
    /// </summary>
    /// <param name="createContinuation">A factory that returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the event returned by awaiting the task returned by calling the given <paramref name="createContinuation"/> factory.</returns>
    public Workflow<TEvent> Then(
        Func<ValueTask<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromValueTaskFactory(_workflow, createContinuation).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with a task factory that takes one argument.
    /// </summary>
    /// <param name="createContinuation">A factory that takes one argument and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the event returned by awaiting the task returned by calling the given <paramref name="createContinuation"/> factory with the given <paramref name="arg"/>ument.</returns>
    public Workflow<TEvent> Then<TArg>(
        Func<TArg, ValueTask<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromValueTaskFactory(_workflow, createContinuation.BindAll(arg)).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with a task factory that takes two arguments.
    /// </summary>
    /// <param name="createContinuation">A factory that takes two arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the event returned by awaiting the task returned by calling the given <paramref name="createContinuation"/> factory with the given arguments.</returns>
    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromValueTaskFactory(_workflow, createContinuation.BindAll(arg1, arg2)).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with a task factory that takes three arguments.
    /// </summary>
    /// <param name="createContinuation">A factory that takes three arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the event returned by awaiting the task returned by calling the given <paramref name="createContinuation"/> factory with the given arguments.</returns>
    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromValueTaskFactory(_workflow, createContinuation.BindAll(arg1, arg2, arg3)).ToWorkflow();
}
