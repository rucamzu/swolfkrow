namespace Swolfkrow.Impl;

internal static partial class WorkflowImpl
{
    public static Workflow<TEvent> ToWorkflow<TEvent>(this IAsyncEnumerable<TEvent> workflow)
        => new(workflow);

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerable<TEvent>(
        IAsyncEnumerable<TEvent> workflow)
        => workflow;

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory<TEvent>(
        Func<IAsyncEnumerable<TEvent>> createWorkflow)
        => AsyncEnumerable.Create(cancellationToken =>
            createWorkflow().GetAsyncEnumerator(cancellationToken));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory1<TArg, TEvent>(
        Func<TArg, IAsyncEnumerable<TEvent>> createWorkflow, TArg arg)
        => StartFromAsyncEnumerableFactory(() => createWorkflow(arg));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2)
        => StartFromAsyncEnumerableFactory(() => createWorkflow(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromAsyncEnumerableFactory(() => createWorkflow(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> StartFromEnumerable<TEvent>(
        IEnumerable<TEvent> workflow)
        => workflow.ToAsyncEnumerable();

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory<TEvent>(
        Func<IEnumerable<TEvent>> createWorkflow)
        => StartFromAsyncEnumerableFactory(() => StartFromEnumerable(createWorkflow()));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory1<TArg, TEvent>(
        Func<TArg, IEnumerable<TEvent>> createWorkflow, TArg arg)
        => StartFromEnumerableFactory(() => createWorkflow(arg));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2)
        => StartFromEnumerableFactory(() => createWorkflow(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, IEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromEnumerableFactory(() => createWorkflow(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory<TEvent>(
        Func<TEvent> createEvent)
        => StartFromEnumerableFactory(() => Enumerable.Repeat(createEvent(), 1));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory1<TArg, TEvent>(
        Func<TArg, TEvent> createEvent, TArg arg)
        => StartFromEventFactory(() => createEvent(arg));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, TEvent> createEvent, TArg1 arg1, TArg2 arg2)
        => StartFromEventFactory(() => createEvent(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, TEvent> createEvent, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromEventFactory(() => createEvent(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> StartFromTask<TEvent>(
        Task<TEvent> task)
        => task.ToAsyncEnumerable();

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory<TEvent>(
        Func<Task<TEvent>> createTask)
        => StartFromAsyncEnumerableFactory(() => StartFromTask(createTask()));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory1<TArg, TEvent>(
        Func<TArg, Task<TEvent>> createTask, TArg arg)
        => StartFromAsyncEnumerableFactory(() => StartFromTask(createTask(arg)));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2)
        => StartFromAsyncEnumerableFactory(() => StartFromTask(createTask(arg1, arg2)));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromAsyncEnumerableFactory(() => StartFromTask(createTask(arg1, arg2, arg3)));

    public static IAsyncEnumerable<TEvent> StartFromValueTask<TEvent>(
        ValueTask<TEvent> valueTask)
        => StartFromTask(valueTask.AsTask());

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory<TEvent>(
        Func<ValueTask<TEvent>> createValueTask)
        => StartFromAsyncEnumerableFactory(() => StartFromValueTask(createValueTask()));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory1<TArg, TEvent>(
        Func<TArg, ValueTask<TEvent>> createValueTask, TArg arg)
        => StartFromAsyncEnumerableFactory(() => StartFromValueTask(createValueTask(arg)));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2)
        => StartFromAsyncEnumerableFactory(() => StartFromValueTask(createValueTask(arg1, arg2)));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromAsyncEnumerableFactory(() => StartFromValueTask(createValueTask(arg1, arg2, arg3)));
}