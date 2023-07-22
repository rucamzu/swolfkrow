using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Interupts the asynchronous <see cref="Workflow{TEvent}"/> right before the first event that does not satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow up to, but excluding, the first event that does not satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public Workflow<TEvent> While(Func<TEvent, Task<bool>> predicate)
        => WorkflowImpl.WhileFromTaskPredicate(_workflow, predicate).ToWorkflow();

    /// <summary>
    /// Interupts the asynchronous <see cref="Workflow{TEvent}"/> right before the first event that does not satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/> and one additional argument.</param>
    /// <param name="arg">The argument passed to the given <paramref name="predicate"/>.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="predicate"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow up to, but excluding, the first event that does not satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public Workflow<TEvent> While<TArg>(
        Func<TEvent, TArg, Task<bool>> predicate, TArg arg)
        => WorkflowImpl.WhileFromTaskPredicate(_workflow, predicate.BindLast(arg)).ToWorkflow();

    /// <summary>
    /// Interupts the asynchronous <see cref="Workflow{TEvent}"/> right before the first event that does not satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/> and one additional argument.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="predicate"/>.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="predicate"/>.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="predicate"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow up to, but excluding, the first event that does not satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public Workflow<TEvent> While<TArg1, TArg2>(
        Func<TEvent, TArg1, TArg2, Task<bool>> predicate, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.WhileFromTaskPredicate(_workflow, predicate.BindLast(arg1, arg2)).ToWorkflow();

    /// <summary>
    /// Interupts the asynchronous <see cref="Workflow{TEvent}"/> right before the first event that does not satisfy an asynchronous predicate.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an <typeparamref name="TEvent"/> and one additional argument.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="predicate"/>.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="predicate"/>.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="predicate"/>.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="predicate"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow up to, but excluding, the first event that does not satisfy the given asynchronous <paramref name="predicate"/>.</returns>
    public Workflow<TEvent> While<TArg1, TArg2, TArg3>(
        Func<TEvent, TArg1, TArg2, TArg3, Task<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.WhileFromTaskPredicate(_workflow, predicate.BindLast(arg1, arg2, arg3)).ToWorkflow();
}