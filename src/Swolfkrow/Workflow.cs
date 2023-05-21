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
    /// <typeparam name="TEvent">The (base) type of the events yielded by the given asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>The given <paramref name="workflow"/>.</returns>
    /// <remarks>
    /// This function serves as an entry point to the DSL. It is an identity function, functionally equivalent to directly accessing the given <paramref name="workflow"/>.
    /// </remarks>
    public static IAsyncEnumerable<TEvent> Start<TEvent>(IAsyncEnumerable<TEvent> workflow)
        => workflow;

    /// <summary>
    /// Starts an asynchronous workflow from a factory function.
    /// </summary>
    /// <param name="createWorkflow">A factory function that creates an asynchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow created by the given <paramref name="createWorkflow"/> factory function.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createWorkflow"/> factory function and yields the events of the resulting asynchronous workflow.</returns>
    /// <remarks>
    /// This function serves as an entry point to the DSL. It is functionally equivalent to directly calling the given <paramref name="createWorkflow"/> factory function.
    /// </remarks>
    public static IAsyncEnumerable<TEvent> Start<TEvent>(Func<IAsyncEnumerable<TEvent>> createWorkflow)
        => AsyncEnumerable.Create(cancellationToken => createWorkflow().GetAsyncEnumerator(cancellationToken));

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
