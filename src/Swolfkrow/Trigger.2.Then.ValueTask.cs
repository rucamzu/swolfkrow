using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>
{
    public Workflow<TEvent> Then(
        Func<TTriggerEvent1, TTriggerEvent2, ValueTask<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromTriggered2ValueTaskFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
            _workflow, _predicate, createContinuation).ToWorkflow();

    public Workflow<TEvent> Then<TArg>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg, ValueTask<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered2ValueTaskFactory1(
            _workflow, _predicate, createContinuation, arg).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered2ValueTaskFactory2(
            _workflow, _predicate, createContinuation, arg1, arg2).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered2ValueTaskFactory3(
            _workflow, _predicate, createContinuation, arg1, arg2, arg3).ToWorkflow();
}