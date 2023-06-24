using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2>(
        Func<TTriggerEvent1, TTriggerEvent2, bool> predicate)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromPredicate(predicate));

    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2, TArg>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg, bool> predicate, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromPredicate1(predicate, arg));

    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, bool> predicate, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromPredicate2(predicate, arg1, arg2));

    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, bool> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this,
            Predicate2.FromPredicate3(predicate, arg1, arg2, arg3));
}
