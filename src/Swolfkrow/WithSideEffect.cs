namespace Swolfkrow;

/// <summary>
/// Factory methods and extension methods to compose asynchronous workflows based on <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static partial class Workflow
{
    /// <summary>
    /// Injects a side effect in an asynchronous workflow.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <param name="sideEffect">An action encapsulating a side effect that takes the next event from the given asynchronous <paramref name="workflow"/> as only argument.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the given asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>An asynchronous workflow that yields the events from the given asynchronous <paramref name="workflow"/> after executing the given side effect on them.</returns>
    public static async IAsyncEnumerable<TEvent> WithSideEffect<TEvent>(this IAsyncEnumerable<TEvent> workflow,
        Action<TEvent> sideEffect)
    {
        await foreach (var nextEvent in workflow)
        {
            sideEffect(nextEvent);

            yield return nextEvent;
        }
    }
}
