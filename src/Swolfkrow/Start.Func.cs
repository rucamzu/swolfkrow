namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Starts an asynchronous workflow from an event factory.
    /// </summary>
    /// <param name="createEvent">A factory that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createEvent"/> factory and yields the resulting event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TEvent>(Func<TEvent> createEvent)
    {
        yield return createEvent();
    }

    /// <summary>
    /// Starts an asynchronous workflow from an event factory that takes one argument.
    /// </summary>
    /// <param name="createEvent">A factory that takes one argument and returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createEvent"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createEvent"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createEvent"/> factory and yields the resulting event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TArg, TEvent>(
        Func<TArg, TEvent> createEvent, TArg arg)
    {
        yield return createEvent(arg);
    }

    /// <summary>
    /// Starts an asynchronous workflow from an event factory that takes two arguments.
    /// </summary>
    /// <param name="createEvent">A factory that takes two arguments and returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createEvent"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createEvent"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createEvent"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createEvent"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createEvent"/> factory and yields the resulting event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, TEvent> createEvent, TArg1 arg1, TArg2 arg2)
    {
        yield return createEvent(arg1, arg2);
    }

    /// <summary>
    /// Starts an asynchronous workflow from an event factory that takes three arguments.
    /// </summary>
    /// <param name="createEvent">A factory that takes three arguments and returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createEvent"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createEvent"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createEvent"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createEvent"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createEvent"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createEvent"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the event yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that calls the given <paramref name="createEvent"/> factory and yields the resulting event.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static async IAsyncEnumerable<TEvent> Start<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, TEvent> createEvent, TArg1 arg1, TArg2 arg2, TArg3 arg3)
    {
        yield return createEvent(arg1, arg2, arg3);
    }
}
