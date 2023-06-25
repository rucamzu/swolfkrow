using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent>()
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this, Predicate1.Always);
}
