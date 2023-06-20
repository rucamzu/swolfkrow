using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Interupts the asynchronous <see cref="Workflow{TEvent}"/> right after the first event that does satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow up to, and including, the first event that does satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public Workflow<TEvent> Until(Func<TEvent, ValueTask<bool>> predicate)
        => WorkflowImpl.UntilFromValueTaskPredicate(_workflow, predicate).ToWorkflow();
}   