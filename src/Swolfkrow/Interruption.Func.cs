namespace Swolfkrow;

/// <summary>
/// Extension methods to conditionally interrupt asynchronous workflows.
/// </summary>
public static partial class Interruption
{
    /// <summary>
    /// Interupts an asynchronous workflow right before the first event that does not satisfy a predicate.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="predicate">A predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/> up to, but excluding, the first event that does not satisfy the given <paramref name="predicate"/>.</returns>
    public static async IAsyncEnumerable<TEvent> While<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, bool> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            if (!predicate(nextEvent))
                yield break;

            yield return nextEvent;
        }        
    }

    /// <summary>
    /// Interupts an asynchronous workflow right after the first event that satisfies a predicate.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="predicate">A predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/> up to, and including, the first event that does not satisfy the given <paramref name="predicate"/>.</returns>
    public static async IAsyncEnumerable<TEvent> Until<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, bool> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (predicate(nextEvent))
                yield break;
        }        
    }
}   