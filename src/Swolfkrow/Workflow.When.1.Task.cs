using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every event of type <typeparamref name="TTriggerEvent"/> yielded by <see langword="this"/> asynchronous workflow that satisfies a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an event of type <typeparamref name="TTriggerEvent"/>.</param>
    /// <typeparam name="TTriggerEvent">The type of the events that trigger the conditional composition.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent>(
        Func<TTriggerEvent, Task<bool>> predicate)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromTaskPredicate(predicate));

    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every event of type <typeparamref name="TTriggerEvent"/> yielded by <see langword="this"/> asynchronous workflow that satisfies a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an event of type <typeparamref name="TTriggerEvent"/> and one additional argument.</param>
    /// <param name="arg">The additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <typeparam name="TTriggerEvent">The type of the events that trigger the conditional composition.</typeparam>
    /// <typeparam name="TArg">The type of the additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg>(
        Func<TTriggerEvent, TArg, Task<bool>> predicate, TArg arg)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromTaskPredicate1(predicate, arg));

    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every event of type <typeparamref name="TTriggerEvent"/> yielded by <see langword="this"/> asynchronous workflow that satisfies a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an event of type <typeparamref name="TTriggerEvent"/> and two additional arguments.</param>
    /// <param name="arg1">The first additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <param name="arg2">The second additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <typeparam name="TTriggerEvent">The type of the events that trigger the conditional composition.</typeparam>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg1, TArg2>(
        Func<TTriggerEvent, TArg1, TArg2, Task<bool>> predicate, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromTaskPredicate2(predicate, arg1, arg2));

    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every event of type <typeparamref name="TTriggerEvent"/> yielded by <see langword="this"/> asynchronous workflow that satisfies a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes an event of type <typeparamref name="TTriggerEvent"/> and two additional arguments.</param>
    /// <param name="arg1">The first additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <param name="arg2">The second additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <param name="arg3">The third additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <typeparam name="TTriggerEvent">The type of the events that trigger the conditional composition.</typeparam>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg3">The type of the third additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg1, TArg2, TArg3>(
        Func<TTriggerEvent, TArg1, TArg2, TArg3, Task<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromTaskPredicate3(predicate, arg1, arg2, arg3));
}
