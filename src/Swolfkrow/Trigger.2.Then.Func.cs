using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>
{
    /// <summary>
    /// Continues triggering events with one single intercalated event produced by a factory that takes the yielded triggering events.
    /// </summary>
    /// <param name="createContinuation">A factory that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> and returns an event of type <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by a new call to the given <paramref name="createContinuation"/> factory after each pair of yielded triggering events.</returns>
    /// <remarks>The triggering events are those of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then(
        Func<TTriggerEvent1, TTriggerEvent2, TEvent> createContinuation)
        => WorkflowImpl.ThenFromTriggered2EventFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
            _workflow, _predicate, createContinuation).ToWorkflow();

    /// <summary>
    /// Continues triggering events with one single intercalated event produced by a factory that takes the yielded triggering events and one additional argument.
    /// </summary>
    /// <param name="createContinuation">A factory that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> and one additional argument, and returns an event of type <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg">The type of the additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by a new call to the given <paramref name="createContinuation"/> factory after each pair of yielded triggering events.</returns>
    /// <remarks>The triggering events are those of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg, TEvent> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered2EventFactory(_workflow, _predicate, createContinuation.BindLast(arg)).ToWorkflow();

    /// <summary>
    /// Continues triggering events with one single intercalated event produced by a factory that takes the yielded triggering events and two additional arguments.
    /// </summary>
    /// <param name="createContinuation">A factory that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> and two additional arguments, and returns an event of type <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by a new call to the given <paramref name="createContinuation"/> factory after each pair of yielded triggering events.</returns>
    /// <remarks>The triggering events are those of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TEvent> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered2EventFactory(_workflow, _predicate, createContinuation.BindLast(arg1, arg2)).ToWorkflow();

    /// <summary>
    /// Continues triggering events with one single intercalated event produced by a factory that takes the yielded triggering events and three additional arguments.
    /// </summary>
    /// <param name="createContinuation">A factory that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> and three additional arguments, and returns an event of type <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg3">The third additional argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third additional argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by a new call to the given <paramref name="createContinuation"/> factory after each pair of yielded triggering events.</returns>
    /// <remarks>The triggering events are those of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, TEvent> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered2EventFactory(_workflow, _predicate, createContinuation.BindLast(arg1, arg2, arg3)).ToWorkflow();
}