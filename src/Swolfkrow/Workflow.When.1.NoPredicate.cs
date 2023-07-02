using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every event of type <typeparamref name="TTriggerEvent"/> yielded by <see langword="this"/> asynchronous workflow.
    /// </summary>
    /// <typeparam name="TTriggerEvent">The type of the events that trigger the conditional composition.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent> When<TTriggerEvent>()
        where TTriggerEvent : TEvent
        => new Trigger<TEvent, TTriggerEvent>(this, Predicate1.Always);
}
