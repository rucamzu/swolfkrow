namespace Swolfkrow;

/// <summary>
/// Factory methods and extension methods to compose asynchronous workflows based on <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static partial class Workflow
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
    /// <param name="createWorkflow">A factory function that returns an asynchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow created by the given <paramref name="createWorkflow"/> factory function.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createWorkflow"/> factory function and yields the events of the resulting asynchronous workflow.</returns>
    /// <remarks>
    /// This function serves as an entry point to the DSL. It is functionally equivalent to directly calling the given <paramref name="createWorkflow"/> factory function.
    /// </remarks>
    public static IAsyncEnumerable<TEvent> Start<TEvent>(Func<IAsyncEnumerable<TEvent>> createWorkflow)
        => AsyncEnumerable.Create(cancellationToken => createWorkflow().GetAsyncEnumerator(cancellationToken));

    /// <summary>
    /// Starts an asynchronous workflow from a factory function that takes one argument.
    /// </summary>
    /// <param name="createWorkflow">A factory function that takes one given <paramref name="arg"/>ument and returns an asynchronous workflow.</param>
    /// <param name="arg">An argument to be passed to the given <paramref name="createWorkflow"/> factory function.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createWorkflow"/> factory function.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow created by the given <paramref name="createWorkflow"/> factory function.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createWorkflow"/> factory function with the given <paramref name="arg"/>ument and yields the events of the resulting asynchronous workflow.</returns>
    /// <remarks>
    /// This function serves as an entry point to the DSL. It is functionally equivalent to directly calling the given <paramref name="createWorkflow"/> factory function with the given <paramref name="arg"/>ument.
    /// </remarks>
    public static IAsyncEnumerable<TEvent> Start<TArg, TEvent>(
        Func<TArg, IAsyncEnumerable<TEvent>> createWorkflow, TArg arg)
        => AsyncEnumerable.Create(cancellationToken => createWorkflow(arg).GetAsyncEnumerator(cancellationToken));
}
