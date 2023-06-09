﻿namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Injects an asynchronous side effect into an asynchronous workflow.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="effect">A function encapsulating an asynchronous side effect that will be executed once per each <typeparamref name="TEvent"/> yielded by the given asynchronous <paramref name="workflow"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the given asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields each <typeparamref name="TEvent"/> from the given asynchronous <paramref name="workflow"/>, after executing the given side <paramref name="effect"/> on each of them.</returns>
    public static async IAsyncEnumerable<TEvent> WithSideEffect<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task> effect)
    {
        await foreach (var nextEvent in workflow)
        {
            await effect(nextEvent);

            yield return nextEvent;
        }
    }
}