using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent, TTriggerEvent>
{
    public Workflow<TEvent> Then(
        Func<TTriggerEvent, Task<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromTriggered1TaskFactory(
            _workflow, _predicate, createContinuation).ToWorkflow();

    public Workflow<TEvent> Then<TArg>(
        Func<TTriggerEvent, TArg, Task<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered1TaskFactory1(
            _workflow, _predicate, createContinuation, arg).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TTriggerEvent, TArg1, TArg2, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered1TaskFactory2(
            _workflow, _predicate, createContinuation, arg1, arg2).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TTriggerEvent, TArg1, TArg2, TArg3, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered1TaskFactory3(
            _workflow, _predicate, createContinuation, arg1, arg2, arg3).ToWorkflow();
}
