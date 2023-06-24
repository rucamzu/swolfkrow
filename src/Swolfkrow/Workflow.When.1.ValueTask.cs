using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent>(
        Func<TTriggerEvent, ValueTask<bool>> predicate)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromValueTaskPredicate(predicate));

    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg>(
        Func<TTriggerEvent, TArg, ValueTask<bool>> predicate, TArg arg)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromValueTaskPredicate1(predicate, arg));

    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg1, TArg2>(
        Func<TTriggerEvent, TArg1, TArg2, ValueTask<bool>> predicate, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromValueTaskPredicate2(predicate, arg1, arg2));

    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent, TArg1, TArg2, TArg3>(
        Func<TTriggerEvent, TArg1, TArg2, TArg3, ValueTask<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this,
            Predicate1.FromValueTaskPredicate3(predicate, arg1, arg2, arg3));
}
