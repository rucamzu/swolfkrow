using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent, TTriggerEvent>
{
    /// <summary>
    /// Continues triggering events with one single intercalated event produced by an asynchronous factory that takes the yielded triggering event.
    /// </summary>
    /// <param name="createContinuation">An asynchronous factory that takes an event of type <typeparamref name="TTriggerEvent"/> and returns [a task that returns] an event of type <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by awaiting a new call to the given <paramref name="createContinuation"/> asynchronous factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those of type <typeparamref name="TTriggerEvent"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then(
        Func<TTriggerEvent, ValueTask<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromTriggered1ValueTaskFactory(
            _workflow, _predicate, createContinuation).ToWorkflow();

    /// <summary>
    /// Continues triggering events with one single intercalated event produced by an asynchronous factory that takes the yielded triggering event and one additional argument.
    /// </summary>
    /// <param name="createContinuation">An asynchronous factory that takes an event of type <typeparamref name="TTriggerEvent"/> and one additional argument, and returns an event of type <typeparamref name="TEvent"/>.</param>
    /// <param name="arg">The additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</param>
    /// <typeparam name="TArg">The type of the additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by awaiting a new call to the given <paramref name="createContinuation"/> asynchronous factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those of type <typeparamref name="TTriggerEvent"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg>(
        Func<TTriggerEvent, TArg, ValueTask<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered1ValueTaskFactory1(
            _workflow, _predicate, createContinuation, arg).ToWorkflow();

    /// <summary>
    /// Continues triggering events with one single intercalated event produced by an asynchronous factory that takes the yielded triggering event and two additional arguments.
    /// </summary>
    /// <param name="createContinuation">An asynchronous factory that takes an event of type <typeparamref name="TTriggerEvent"/> and two additional arguments, and returns an event of type <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</param>
    /// <param name="arg2">The second additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</param>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by awaiting a new call to the given <paramref name="createContinuation"/> asynchronous factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those of type <typeparamref name="TTriggerEvent"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TTriggerEvent, TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered1ValueTaskFactory2(
            _workflow, _predicate, createContinuation, arg1, arg2).ToWorkflow();

    /// <summary>
    /// Continues triggering events with one single intercalated event produced by an asynchronous factory that takes the yielded triggering event and three additional arguments.
    /// </summary>
    /// <param name="createContinuation">An asynchronous factory that takes an event of type <typeparamref name="TTriggerEvent"/> and three additional arguments, and returns an event of type <typeparamref name="TEvent"/>.</param>
    /// <param name="arg1">The first additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</param>
    /// <param name="arg2">The second additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</param>
    /// <param name="arg3">The third additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</param>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third additional argument passed to the given <paramref name="createContinuation"/> asynchronous factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, and intercalates the event returned by awaiting a new call to the given <paramref name="createContinuation"/> asynchronous factory after each yielded triggering event.</returns>
    /// <remarks>The triggering events are those of type <typeparamref name="TTriggerEvent"/> that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TTriggerEvent, TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered1ValueTaskFactory3(
            _workflow, _predicate, createContinuation, arg1, arg2, arg3).ToWorkflow();
}
