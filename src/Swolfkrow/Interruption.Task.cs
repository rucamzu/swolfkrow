namespace Swolfkrow;

public static partial class Interruption
{
    /// <summary>
    /// Interupts an asynchronous workflow right before the first event that does not satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/> up to, but excluding, the first event that does not satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public static async IAsyncEnumerable<TEvent> While<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            if (!await predicate(nextEvent))
                yield break;

            yield return nextEvent;
        }        
    }

    /// <summary>
    /// Interupts an asynchronous workflow right after the first event that does not satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous workflow that yields the events yielded by the given asynchronous <paramref name="workflow"/> up to, and including, the first event that does not satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public static async IAsyncEnumerable<TEvent> Until<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (!await predicate(nextEvent))
                yield break;
        }        
    }
}   