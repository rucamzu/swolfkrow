using Swolfkrow.Impl;

namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task.
    /// </summary>
    /// <param name="task">A task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the given <paramref name="task"/>.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(ValueTask<TEvent> task)
        => WorkflowImpl.StartFromValueTask(task).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory.
    /// </summary>
    /// <param name="createValueTask">A factory that returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createValueTask"/> factory.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(Func<ValueTask<TEvent>> createValueTask)
        => WorkflowImpl.StartFromValueTaskFactory(createValueTask).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory that takes one argument.
    /// </summary>
    /// <param name="createValueTask">A factory that takes one argument and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createValueTask"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createValueTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createValueTask"/> factory with the given <paramref name="arg"/>ument.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg, TEvent>(
        Func<TArg, ValueTask<TEvent>> createValueTask, TArg arg)
        => WorkflowImpl.StartFromValueTaskFactory1(createValueTask, arg).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory that takes two arguments.
    /// </summary>
    /// <param name="createValueTask">A factory that takes two arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createValueTask"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createValueTask"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createValueTask"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createValueTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createValueTask"/> factory with the given arguments.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.StartFromValueTaskFactory2(createValueTask, arg1, arg2).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory that takes three arguments.
    /// </summary>
    /// <param name="createValueTask">A factory that takes three arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createValueTask"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createValueTask"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createValueTask"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createValueTask"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createValueTask"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createValueTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createValueTask"/> factory with the given arguments.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.StartFromValueTaskFactory3(createValueTask, arg1, arg2, arg3).ToWorkflow();
}
