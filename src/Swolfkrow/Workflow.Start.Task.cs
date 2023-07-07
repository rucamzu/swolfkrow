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
    public static Workflow<TEvent> Start<TEvent>(Task<TEvent> task)
        => WorkflowImpl.StartFromTask(task).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory.
    /// </summary>
    /// <param name="createTask">A factory that returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createTask"/> factory.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(Func<Task<TEvent>> createTask)
        => WorkflowImpl.StartFromTaskFactory(createTask).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory that takes one argument.
    /// </summary>
    /// <param name="createTask">A factory that takes one argument and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createTask"/> factory with the given <paramref name="arg"/>ument.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg, TEvent>(
        Func<TArg, Task<TEvent>> createTask, TArg arg)
        => WorkflowImpl.StartFromTaskFactory(createTask.BindAll(arg)).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory that takes two arguments.
    /// </summary>
    /// <param name="createTask">A factory that takes two arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createTask"/> factory with the given arguments.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.StartFromTaskFactory(createTask.BindAll(arg1, arg2)).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a task factory that takes three arguments.
    /// </summary>
    /// <param name="createTask">A factory that takes three arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the event returned by awaiting the task returned by calling the given <paramref name="createTask"/> factory with the given arguments.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.StartFromTaskFactory(createTask.BindAll(arg1, arg2, arg3)).ToWorkflow();
}
