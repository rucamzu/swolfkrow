using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2>()
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this, Predicate2.Always);
}
