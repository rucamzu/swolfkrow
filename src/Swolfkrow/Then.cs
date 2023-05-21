﻿namespace Swolfkrow;

/// <summary>
/// Factory methods and extension methods to compose asynchronous workflows based on <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static partial class Workflow
{
    /// <summary>
    /// Chains two existing asynchronous workflows. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="continuation">An existing asynchronous workflow that is to be executed as continuation to the given <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by both chained asynchronous workflows.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/>, followed by the given <paramref name="continuation"/>.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        IAsyncEnumerable<TEvent> continuation)
        => workflow.Concat(Workflow.Start(continuation));

    /// <summary>
    /// Chains an existing asynchronous workflow to the asynchronous workflow created by a factory function. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory function that creates an asynchronous workflow that is to be executed as continuation to the given <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by both chained asynchronous workflows.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/>, followed by an asynchronous workflow that calls the given <paramref name="createContinuation"/> factory function and yields the events of the resulting asynchronous workflow.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<IAsyncEnumerable<TEvent>> createContinuation)
        => workflow.Concat(Workflow.Start(createContinuation));
}