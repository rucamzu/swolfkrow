using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent>(
        Func<TTriggerEvent, bool> predicate)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromPredicate(predicate));

    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg>(
        Func<TTriggerEvent, TArg, bool> predicate, TArg arg)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromPredicate1(predicate, arg));

    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg1, TArg2>(
        Func<TTriggerEvent, TArg1, TArg2, bool> predicate, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromPredicate2(predicate, arg1, arg2));

    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg1, TArg2, TArg3>(
        Func<TTriggerEvent, TArg1, TArg2, TArg3, bool> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromPredicate3(predicate, arg1, arg2, arg3));
}
