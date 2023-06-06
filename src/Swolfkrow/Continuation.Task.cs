﻿namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Continues an asynchronous workflow with a task. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="continuation">A task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the event returned by the given <paramref name="continuation"/> task.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Task<TEvent> continuation)
        => workflow.Concat(Workflow.Start(continuation));

    /// <summary>
    /// Continues an existing asynchronous workflow with a task created by a factory. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the event returned by the task created by the given <paramref name="createContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<Task<TEvent>> createContinuation)
        => workflow.Concat(Workflow.Start(createContinuation));

    /// <summary>
    /// Continues an existing asynchronous workflow with a task created by a factory that takes one argument.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes one argument and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the event returned by the task created by the given <paramref name="createContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg, Task<TEvent>> createContinuation, TArg arg)
        => workflow.Concat(Workflow.Start(createContinuation, arg));

    /// <summary>
    /// Continues an existing asynchronous workflow with a task created by a factory that takes two arguments.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes two arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the event returned by the task created by the given <paramref name="createContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg1, TArg2, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => workflow.Concat(Workflow.Start(createContinuation, arg1, arg2));

    /// <summary>
    /// Continues an existing asynchronous workflow with a task created by a factory that takes three arguments.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes three arguments and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the event returned by the task created by the given <paramref name="createContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg1, TArg2, TArg3, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => workflow.Concat(Workflow.Start(createContinuation, arg1, arg2, arg3));
}
