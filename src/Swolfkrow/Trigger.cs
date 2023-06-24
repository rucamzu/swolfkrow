namespace Swolfkrow;

/// <summary>
/// The prelude to a conditional composition on an asynchronous workflow that depends on one yielded event.
/// </summary>
/// <typeparam name="TEvent">The type of the events yielded by the asynchronous workflow.</typeparam>
/// <typeparam name="TTriggerEvent">The type of the event that trigger the composition.</typeparam>
/// <remarks>The <see cref="Trigger{TEvent, TTriggerEvent}"/> class enables the declaration of two-step conditional compositions on asynchronous workflows, by storing the information relative to the triggering condition as specified in the initial call to any of the 'When' method overloads, and exposing in turn methods that allow defining the triggered action.</remarks>
public partial class Trigger<TEvent, TTriggerEvent>
    where TTriggerEvent : TEvent
{
    private readonly Workflow<TEvent> _workflow;
    private readonly Func<TTriggerEvent, Task<bool>> _predicate;

    internal Trigger(
        Workflow<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate)
    {
        _workflow = workflow;
        _predicate = predicate;
    }
}

/// <summary>
/// The prelude to a conditional composition on an asynchronous workflow that depends on two yielded events.
/// </summary>
/// <typeparam name="TEvent">The type of the events yielded by the asynchronous workflow.</typeparam>
/// <typeparam name="TTriggerEvent1">The type of the first event that triggers the composition.</typeparam>
/// <typeparam name="TTriggerEvent2">The type of the second event that triggers the composition.</typeparam>
/// <remarks>The <see cref="Trigger{TEvent, TTriggerEvent1, TTriggeredEvent2}"/> class enables the declaration of two-step conditional compositions on asynchronous workflows, by storing the information relative to the triggering condition as specified in the initial call to any of the 'When' method overloads, and exposing in turn methods that allow defining the triggered action.</remarks>
public partial class Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>
    where TTriggerEvent1 : TEvent
    where TTriggerEvent2 : TEvent
{
    private readonly Workflow<TEvent> _workflow;
    private readonly Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> _predicate;

    internal Trigger(
        Workflow<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate)
    {
        _workflow = workflow;
        _predicate = predicate;
    }
}