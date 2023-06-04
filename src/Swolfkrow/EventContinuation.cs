namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Continues each event yielded by an existing asynchronous workflow with an intercalated asynchronous workflow created by a factory.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an <typeparamref name="TEvent"/> and returns an asynchronous <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields all events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each one the asynchronous workflow produced by the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, IAsyncEnumerable<TEvent>> createEventContinuation)
        => workflow.SelectMany(nextEvent => Workflow.Start(nextEvent).Then(createEventContinuation, nextEvent));

    /// <summary>
    /// Continues each event yielded by an existing asynchronous workflow that satisfies a given predicate with an intercalated asynchronous workflow created by a factory.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an <typeparamref name="TEvent"/> and returns an asynchronous <paramref name="workflow"/>.</param>
    /// <param name="predicate">A predicate computed for each event yielded by the given asynchronous <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields all events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each one that satisfies the given <paramref name="predicate"/> the asynchronous workflow produced by the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, IAsyncEnumerable<TEvent>> createEventContinuation,
        Func<TEvent, bool> predicate)
        => workflow.SelectMany(nextEvent =>
            predicate(nextEvent)
                ? Workflow.Start(nextEvent).Then(createEventContinuation, nextEvent)
                : Workflow.Start(nextEvent));

    /// <summary>
    /// Continues each event of the given subtype yielded by an existing asynchronous workflow with an intercalated asynchronous workflow created by a factory.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an event of the given <typeparamref name="TContinuedEvent"/> subtype and returns an asynchronous <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <typeparam name="TContinuedEvent">The type of the continued events.</typeparam>
    /// <returns>An asynchronous workflow that yields all events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each event of the given <typeparamref name="TContinuedEvent"/> subtype the asynchronous workflow produced by the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent, TContinuedEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TContinuedEvent, IAsyncEnumerable<TEvent>> createEventContinuation)
        where TContinuedEvent : TEvent
        => workflow.SelectMany(nextEvent => nextEvent switch {
            TContinuedEvent continuedEvent => Workflow.Start<TEvent>(continuedEvent).Then(createEventContinuation, continuedEvent),
            _ => Workflow.Start(nextEvent)
        });

    /// <summary>
    /// Continues each event of the given subtype yielded by an existing asynchronous workflow that satisfies a given predicate with an intercalated asynchronous workflow created by a factory.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an event of the given <typeparamref name="TContinuedEvent"/> subtype and returns an asynchronous <paramref name="workflow"/>.</param>
    /// <param name="predicate">A predicate computed for each event of the given subtype yielded by the given asynchronous <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <typeparam name="TContinuedEvent">The type of the continued events.</typeparam>
    /// <returns>An asynchronous workflow that yields all events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each event of the given <typeparamref name="TContinuedEvent"/> subtype that satisfies the given <paramref name="predicate"/> the asynchronous workflow produced by the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent, TContinuedEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TContinuedEvent, IAsyncEnumerable<TEvent>> createEventContinuation,
        Func<TContinuedEvent, bool> predicate)
        where TContinuedEvent : TEvent
        => workflow.SelectMany(nextEvent => nextEvent switch {
            TContinuedEvent continuedEvent when predicate(continuedEvent) => Workflow.Start<TEvent>(continuedEvent).Then(createEventContinuation, continuedEvent),
            _ => Workflow.Start(nextEvent)
        });
}