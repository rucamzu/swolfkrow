namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Continues each one of the events yielded by an existing asynchronous workflow with an intercalated asynchronous workflow created by a factory function.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory function that creates a continuation workflow from each one of the events yielded by the given asynchronous <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflows.</typeparam>
    /// <returns>The asynchronous workflow resulting from continuing each of the events yielded by the given asynchronous <paramref name="workflow"/> with the asynchronous workflow produced by the given factory function.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, IAsyncEnumerable<TEvent>> createEventContinuation)
        => workflow.SelectMany(nextEvent => Workflow.Start(nextEvent).Then(createEventContinuation, nextEvent));

    /// <summary>
    /// Continues each one of the events of the given subtype yielded by an existing asynchronous workflow with an intercalated asynchronous workflow created by a factory function.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="createEventContinuation">A factory function that creates a continuation workflow from each one of the events of the given <paramref name="TContinuedEvent"> subtype yielded by the given asynchronous <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflows.</typeparam>
    /// <typeparam name="TContinuedEvent">The type of the events that are to be continued.</typeparam>
    /// <returns>The asynchronous workflow resulting from continuing each of the events of the given subtype yielded by the given asynchronous <paramref name="workflow"/> with the asynchronous workflow produced by the given factory function.</returns>
    public static IAsyncEnumerable<TEvent> ThenForEach<TEvent, TContinuedEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TContinuedEvent, IAsyncEnumerable<TEvent>> createEventContinuation)
        where TContinuedEvent : TEvent
        => workflow.SelectMany(nextEvent => nextEvent switch {
            TContinuedEvent continuedEvent => Workflow.Start<TEvent>(continuedEvent).Then(createEventContinuation, continuedEvent),
            _ => Workflow.Start(nextEvent)
        });
}