using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Interupts the asynchronous <see cref="Workflow{TEvent}"/> right before the first event that does not satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow up to, but excluding, the first event that does not satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public Workflow<TEvent> While(Func<TEvent, ValueTask<bool>> predicate)
        => WorkflowImpl.WhileFromValueTaskPredicate(_workflow, predicate).ToWorkflow();
}   