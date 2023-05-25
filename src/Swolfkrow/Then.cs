namespace Swolfkrow;

/// <summary>
/// Factory methods and extension methods to compose asynchronous workflows based on <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static partial class Workflow
{
    /// <summary>
    /// Continues an existing asynchronous workflow with a second existing asynchronous workflow. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="continuation">An existing asynchronous workflow that is to be executed as continuation to the given <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by both chained asynchronous workflows.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/>, followed by the given <paramref name="continuation"/>.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        IAsyncEnumerable<TEvent> continuation)
        => workflow.Concat(Workflow.Start(continuation));

    /// <summary>
    /// Continues an existing asynchronous workflow with the asynchronous workflow created by a factory function. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory function that returns an asynchronous workflow that is to be executed as continuation to the given <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by both chained asynchronous workflows.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/>, followed by an asynchronous workflow that calls the given <paramref name="createContinuation"/> factory function and yields the events of the resulting asynchronous workflow.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<IAsyncEnumerable<TEvent>> createContinuation)
        => workflow.Concat(Workflow.Start(createContinuation));

    /// <summary>
    /// Continues an existing asynchronous workflow with the asynchronous workflow created by a factory function that takes one argument.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory function that takes one argument and returns an asynchronous workflow that is to be executed as continuation to the given <paramref name="workflow"/>.</param>
    /// <param name="arg">An argument to be passed to the given <paramref name="createContinuation"/> factory function.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createContinuation"/> factory function.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by both chained asynchronous workflows.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/>, followed by an asynchronous workflow that calls the given <paramref name="createContinuation"/> factory function with the given <paramref name="arg"/>ument and yields the events of the resulting asynchronous workflow.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg, IAsyncEnumerable<TEvent>> createContinuation, TArg arg)
        => workflow.Concat(Workflow.Start(createContinuation, arg));

    /// <summary>
    /// Continues an existing asynchronous workflow with the asynchronous workflow created by a factory function that takes two arguments. 
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createContinuation">A factory function that takes two arguments and returns an asynchronous workflow that is to be executed as continuation to the given <paramref name="workflow"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory function.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory function.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory function.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory function.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by both chained asynchronous workflows.</typeparam>
    /// <returns>An asynchronous workflow composed of the given <paramref name="workflow"/>, followed by an asynchronous workflow that calls the given <paramref name="createContinuation"/> factory function with the given arguments and yields the events of the resulting asynchronous workflow.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg1, TArg2, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => workflow.Concat(Workflow.Start(createContinuation, arg1, arg2));
}
