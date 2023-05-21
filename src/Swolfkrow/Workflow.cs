namespace Swolfkrow;

/// <summary>
/// Factory methods and extension methods to compose asynchronous workflows based on <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static class Workflow
{
    /// <summary>
    /// Starts an existing asynchronous workflow.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>The given <paramref name="workflow"/>.</returns>
    /// <remarks>
    /// This function does nothing apart from returning the existing asynchronous workflow. Its purpose is to serve as entry point for the DSL. 
    /// </remarks>
    public static IAsyncEnumerable<TEvent> Start<TEvent>(IAsyncEnumerable<TEvent> workflow)
        => workflow;

    /// <summary>
    /// Starts an asynchronous workflow from a factory function.
    /// </summary>
    /// <param name="start">A factory function that creates an asynchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that <paramref name="start"/>s the underlying asynchronous workflow when iterated.</returns>
    /// <remarks>
    /// This function is functionally equivalent to just calling `start()`. Its purpose is to serve as entry point for the DSL. 
    /// </remarks>
    public static IAsyncEnumerable<TEvent> Start<TEvent>(Func<IAsyncEnumerable<TEvent>> start)
        => AsyncEnumerable.Create(cancellationToken => start().GetAsyncEnumerator(cancellationToken));

    /// <summary>
    /// Chains two existing asynchronous workflows. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="continuation">An existing asynchronous workflow that will be executed as continuation of the initial <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the resulting asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/> followed by the given <paramref name="continuation"/>.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        IAsyncEnumerable<TEvent> continuation)
        => workflow.Concat(Workflow.Start(continuation));

    /// <summary>
    /// Chains an existing asynchronous workflow to a existing asynchronous workflows. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="startContinuation">A factory function that creates an asynchronous workflow that will be executed as continuation of the initial <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the resulting asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/> followed by the given <paramref name="startContinuation"/>.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<IAsyncEnumerable<TEvent>> startContinuation)
        => workflow.Concat(Workflow.Start(startContinuation));
}
