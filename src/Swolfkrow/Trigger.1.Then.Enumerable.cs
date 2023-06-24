using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent, TTriggerEvent>
{
    public Workflow<TEvent> Then(
        Func<TTriggerEvent, IEnumerable<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromTriggered1EnumerableFactory(
            _workflow, _predicate, createContinuation).ToWorkflow();

    public Workflow<TEvent> Then<TArg>(
        Func<TTriggerEvent, TArg, IEnumerable<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered1EnumerableFactory1(
            _workflow, _predicate, createContinuation, arg).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TTriggerEvent, TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered1EnumerableFactory2(
            _workflow, _predicate, createContinuation, arg1, arg2).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TTriggerEvent, TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered1EnumerableFactory3(
            _workflow, _predicate, createContinuation, arg1, arg2, arg3).ToWorkflow();
}
