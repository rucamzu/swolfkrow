namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Continues an asynchronous workflow with a given sequence of <paramref name="events"/>.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="events">A sequence of events.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the given <paramref name="events"/>.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        params TEvent[] events)
        => workflow.Concat(Workflow.Start(events));

    /// <summary>
    /// Continues an asynchronous workflow with a synchronous workflow. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="continuation">A synchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the given synchronous workflow <paramref name="continuation"/>.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        IEnumerable<TEvent> continuation)
        => workflow.Concat(Workflow.Start(continuation));

    /// <summary>
    /// Continues an asynchronous workflow with a synchronous workflow factory. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that returns a synchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the synchronous workflow returned by calling the given <paramref name="createContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> Then<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<IEnumerable<TEvent>> createContinuation)
        => workflow.Concat(Workflow.Start(createContinuation));

    /// <summary>
    /// Continues an asynchronous workflow with a synchronous workflow factory that takes one argument.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes one argument and returns a synchronous workflow.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the synchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the given <paramref name="arg"/>ument.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg, IEnumerable<TEvent>> createContinuation, TArg arg)
        => workflow.Concat(Workflow.Start(createContinuation, arg));

    /// <summary>
    /// Continues an asynchronous workflow with a synchronous workflow factory that takes two arguments. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes two arguments and returns a synchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the synchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the given arguments.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg1, TArg2, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => workflow.Concat(Workflow.Start(createContinuation, arg1, arg2));

    /// <summary>
    /// Continues an asynchronous workflow with a synchronous workflow factory that takes three arguments. 
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createContinuation">A factory that takes three arguments and returns a synchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, followed by the events yielded by the synchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the given arguments.</returns>
    public static IAsyncEnumerable<TEvent> Then<TArg1, TArg2, TArg3, TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => workflow.Concat(Workflow.Start(createContinuation, arg1, arg2, arg3));
}
