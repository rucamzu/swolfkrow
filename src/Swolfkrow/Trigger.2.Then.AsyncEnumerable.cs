using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent, TTriggerEvent1, TTriggerEvent2>
{
    public Workflow<TEvent> Then(
        Func<TTriggerEvent1, TTriggerEvent2, IAsyncEnumerable<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromTriggered2AsyncEnumerableFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
            _workflow, _predicate, createContinuation).ToWorkflow();

    public Workflow<TEvent> Then<TArg>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg, IAsyncEnumerable<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromTriggered2AsyncEnumerableFactory1(
            _workflow, _predicate, createContinuation, arg).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromTriggered2AsyncEnumerableFactory2(
            _workflow, _predicate, createContinuation, arg1, arg2).ToWorkflow();

    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromTriggered2AsyncEnumerableFactory3(
            _workflow, _predicate, createContinuation, arg1, arg2, arg3).ToWorkflow();
}