using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Interupts the asynchronous <see cref="Workflow{TEvent}"/> right after the first event that does satisfy a predicate.
    /// </summary>
    /// <param name="predicate">A predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow up to, and including, the first event that does satisfy the given <paramref name="predicate"/>.</returns>
   public IAsyncEnumerable<TEvent> Until(Func<TEvent, bool> predicate)
        => WorkflowImpl.UntilFromPredicate(_workflow, predicate).ToWorkflow();
}