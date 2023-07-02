using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every pair of events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> yielded in any order by <see langword="this"/> asynchronous workflow that satisfy a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/>.</param>
    /// <typeparam name="TTriggerEvent1">The type of the first event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TTriggerEvent2">The type of the second event that triggers the conditional composition.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2>(
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromTaskPredicate(predicate));

    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every pair of events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> yielded in any order by <see langword="this"/> asynchronous workflow that satisfy a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> and one additional argument.</param>
    /// <param name="arg">The additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <typeparam name="TTriggerEvent1">The type of the first event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TTriggerEvent2">The type of the second event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TArg">The type of the additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2, TArg>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg, Task<bool>> predicate, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromTaskPredicate1(predicate, arg));

    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every pair of events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> yielded in any order by <see langword="this"/> asynchronous workflow that satisfy a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">An asynchronous predicate that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> and two additional arguments.</param>
    /// <param name="arg1">The first additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <param name="arg2">The second additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <typeparam name="TTriggerEvent1">The type of the first event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TTriggerEvent2">The type of the second event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, Task<bool>> predicate, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromTaskPredicate2(predicate, arg1, arg2));

    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every pair of events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> yielded in any order by <see langword="this"/> asynchronous workflow that satisfy a given asynchronous <paramref name="predicate"/>.
    /// </summary>
    /// <param name="predicate">A predicate that takes two events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> and three additional arguments.</param>
    /// <param name="arg1">The first additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <param name="arg2">The second additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <param name="arg3">The third additional argument passed to the given asynchronous <paramref name="predicate"/>.</param>
    /// <typeparam name="TTriggerEvent1">The type of the first event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TTriggerEvent2">The type of the second event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TArg1">The type of the first additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <typeparam name="TArg3">The type of the third additional argument passed to the given asynchronous <paramref name="predicate"/>.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, Task<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromTaskPredicate3(predicate, arg1, arg2, arg3));
}
