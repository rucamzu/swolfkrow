using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent>
{
    /// <summary>
    /// Continues triggering events with a synchronous workflow produced by a factory that takes the yielded triggering event.
    /// </summary>
    /// <param name="createContinuation">A factory that takes an event of type <typeparamref name="TEvent"/> and returns a synchronous workflow.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the synchronous workflow returned by a new call to the given <paramref name="createContinuation"/> factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then(
        Func<TEvent, IEnumerable<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromTriggered0EnumerableFactory(
            _workflow, _predicate, createContinuation).ToWorkflow();

    /// <summary>
    /// Continues triggering events with a synchronous workflow produced by a factory that takes the yielded triggering event and one additional argument.
    /// </summary>
    /// <param name="createContinuation">A factory that takes an event of type <typeparamref name="TEvent"/> and one additional argument and returns a synchronous workflow.</param>
    /// <param name="arg">The additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg">The type of the additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the synchronous workflow returned by a new call to the given <paramref name="createContinuation"/> factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg>(
        Func<TEvent, TArg, IEnumerable<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered0EnumerableFactory1(
            _workflow, _predicate, createContinuation, arg).ToWorkflow();

    /// <summary>
    /// Continues triggering events with a synchronous workflow produced by a factory that takes the yielded triggering event and two additional arguments.
    /// </summary>
    /// <param name="createContinuation">A factory that takes an event of type <typeparamref name="TEvent"/> and two additional arguments and returns a synchronous workflow.</param>
    /// <param name="arg1">The first additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the synchronous workflow returned by a new call to the given <paramref name="createContinuation"/> factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TEvent, TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered0EnumerableFactory2(
            _workflow, _predicate, createContinuation, arg1, arg2).ToWorkflow();

    /// <summary>
    /// Continues triggering events with a synchronous workflow produced by a factory that takes the yielded triggering event and three additional arguments.
    /// </summary>
    /// <param name="createContinuation">A factory that takes an event of type <typeparamref name="TEvent"/> and three additional arguments and returns a synchronous workflow.</param>
    /// <param name="arg1">The first additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg3">The third additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the synchronous workflow returned by a new call to the given <paramref name="createContinuation"/> factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TEvent, TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered0EnumerableFactory3(
            _workflow, _predicate, createContinuation, arg1, arg2, arg3).ToWorkflow();
}
