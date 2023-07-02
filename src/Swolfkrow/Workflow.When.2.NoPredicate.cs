using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Initiates a two-step conditional composition that will be triggered by every pair of events of types <typeparamref name="TTriggerEvent1"/> and <typeparamref name="TTriggerEvent2"/> yielded in any order by <see langword="this"/> asynchronous workflow.
    /// </summary>
    /// <typeparam name="TTriggerEvent1">The type of the first event that triggers the conditional composition.</typeparam>
    /// <typeparam name="TTriggerEvent2">The type of the second event that triggers the conditional composition.</typeparam>
    /// <returns>A DSL trigger object used to complete the two-step conditional composition on <see langword="this"/> asynchronous workflow.</returns>
    public Trigger<TEvent, TTriggerEvent1, TTriggerEvent2> When<TTriggerEvent1, TTriggerEvent2>()
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => new Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>(this, Predicate2.Always);
}
