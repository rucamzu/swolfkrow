namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Continues asynchronous workflow events with an intercalated task factory.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an <typeparamref name="TEvent"/> and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each one the event returned by awaiting the task returned by calling the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, ValueTask<TEvent>> createEventContinuation)
        => workflow.SelectMany(nextEvent => Workflow.Start(nextEvent).Then(createEventContinuation, nextEvent));

    /// <summary>
    /// Continues asynchronous workflow events that satisfy a given predicate with an intercalated task factory.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an <typeparamref name="TEvent"/> and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="predicate">A predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each one that satisfies the given <paramref name="predicate"/> the event returned by awaiting the task returned by calling the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, ValueTask<TEvent>> createEventContinuation,
        Func<TEvent, bool> predicate)
        => workflow.SelectMany(nextEvent =>
            predicate(nextEvent)
                ? Workflow.Start(nextEvent).Then(createEventContinuation, nextEvent)
                : Workflow.Start(nextEvent));

    /// <summary>
    /// Continues asynchronous workflow events of a specific subtype with an intercalated task factory.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an event of the given <typeparamref name="TContinuedEvent"/> subtype and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <typeparam name="TContinuedEvent">The type of the continued events and subtype of <typeparamref name="TEvent"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each one of the given <typeparamref name="TContinuedEvent"/> subtype the event returned by awaiting the task returned by calling the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent, TContinuedEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TContinuedEvent, ValueTask<TEvent>> createEventContinuation)
        where TContinuedEvent : TEvent
        => workflow.SelectMany(nextEvent => nextEvent switch {
            TContinuedEvent continuedEvent => Workflow.Start<TEvent>(continuedEvent).Then(createEventContinuation, continuedEvent),
            _ => Workflow.Start(nextEvent)
        });

    /// <summary>
    /// Continues asynchronous workflow events of a specific subtype that satisfy a given predicate with an intercalated task factory.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory that takes an event of the given <typeparamref name="TContinuedEvent"/> subtype and returns a task that returns an <typeparamref name="TEvent"/>.</param>
    /// <param name="predicate">A predicate that takes an event of the given <typeparamref name="TContinuedEvent"/> subtype.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <typeparam name="TContinuedEvent">The type of the continued events and subtype of <typeparamref name="TEvent"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/>, intercalating after each one of the given <typeparamref name="TContinuedEvent"/> subtype that satisfies the given <paramref name="predicate"/> the event returned by awaiting the task returned by calling the given <paramref name="createEventContinuation"/> factory.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent, TContinuedEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TContinuedEvent, ValueTask<TEvent>> createEventContinuation,
        Func<TContinuedEvent, bool> predicate)
        where TContinuedEvent : TEvent
        => workflow.SelectMany(nextEvent => nextEvent switch {
            TContinuedEvent continuedEvent when predicate(continuedEvent) => Workflow.Start<TEvent>(continuedEvent).Then(createEventContinuation, continuedEvent),
            _ => Workflow.Start(nextEvent)
        });
}