using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent, TTriggerEvent>
{
    public Workflow<TEvent> Then(
        Func<TTriggerEvent, TEvent> createContinuation)
        => WorkflowImpl.ThenFromTriggered1EventFactory(
            _workflow, _predicate, createContinuation).ToWorkflow();

    public Workflow<TEvent> Then<TArg>(
        Func<TTriggerEvent, TArg, TEvent> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered1EventFactory1(
            _workflow, _predicate, createContinuation, arg).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TTriggerEvent, TArg1, TArg2, TEvent> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered1EventFactory2(
            _workflow, _predicate, createContinuation, arg1, arg2).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TTriggerEvent, TArg1, TArg2, TArg3, TEvent> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered1EventFactory3(
            _workflow, _predicate, createContinuation, arg1, arg2, arg3).ToWorkflow();
}
