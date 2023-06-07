﻿namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Starts an asynchronous workflow from a task.
    /// </summary>
    /// <param name="task">A task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the result of the given <paramref name="task"/> as its only event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TEvent>(ValueTask<TEvent> task)
    {
        yield return await task;
    }

    /// <summary>
    /// Starts an asynchronous workflow from a task factory.
    /// </summary>
    /// <param name="createTask">A factory that returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createTask"/> factory and yields the result of the resulting task as its only event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TEvent>(Func<ValueTask<TEvent>> createTask)
    {
        yield return await createTask();
    }

    /// <summary>
    /// Starts an asynchronous workflow from a task factory that takes one argument.
    /// </summary>
    /// <param name="createTask">A factory that returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createTask"/> factory with the given <paramref name="arg"/>uments and yields the result of the resulting task as its only event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TArg, TEvent>(
        Func<TArg, ValueTask<TEvent>> createTask, TArg arg)
    {
        yield return await createTask(arg);
    }

    /// <summary>
    /// Starts an asynchronous workflow from a task factory that takes two arguments.
    /// </summary>
    /// <param name="createTask">A factory that takes two arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createTask"/> factory with the given arguments and yields the result of the resulting task as its only event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, ValueTask<TEvent>> createTask, TArg1 arg1, TArg2 arg2)
    {
        yield return await createTask(arg1, arg2);
    }

    /// <summary>
    /// Starts an asynchronous workflow from a task factory that takes three arguments.
    /// </summary>
    /// <param name="createTask">A factory that takes three arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createTask"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createTask"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createTask"/> factory with the given arguments and yields the result of the resulting task as its only event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, ValueTask<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
    {
        yield return await createTask(arg1, arg2, arg3);
    }
}
