namespace Swolfkrow.Impl;

internal static partial class WorkflowImpl
{
    public static Workflow<TEvent> ToWorkflow<TEvent>(this IAsyncEnumerable<TEvent> asyncEnumerable)
        => new(asyncEnumerable);

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerable<TEvent>(
        IAsyncEnumerable<TEvent> asyncEnumerable)
        => asyncEnumerable;

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory<TEvent>(
        Func<IAsyncEnumerable<TEvent>> createAsyncEnumerable)
        => AsyncEnumerable.Create(cancellationToken =>
            createAsyncEnumerable().GetAsyncEnumerator(cancellationToken));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory1<TArg, TEvent>(
        Func<TArg, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg arg)
        => StartFromAsyncEnumerableFactory(() => createAsyncEnumerable(arg));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2)
        => StartFromAsyncEnumerableFactory(() => createAsyncEnumerable(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromAsyncEnumerableFactory(() => createAsyncEnumerable(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> StartFromEnumerable<TEvent>(
        IEnumerable<TEvent> enumerable)
        => enumerable.ToAsyncEnumerable();

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory<TEvent>(
        Func<IEnumerable<TEvent>> createEnumerable)
        => StartFromAsyncEnumerableFactory(() => StartFromEnumerable(createEnumerable()));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory1<TArg, TEvent>(
        Func<TArg, IEnumerable<TEvent>> createEnumerable, TArg arg)
        => StartFromEnumerableFactory(() => createEnumerable(arg));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2)
        => StartFromEnumerableFactory(() => createEnumerable(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromEnumerableFactory(() => createEnumerable(arg1, arg2, arg3));

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

    public static IAsyncEnumerable<TEvent> ThenFromAsyncEnumerable<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        IAsyncEnumerable<TEvent> asyncEnumerable)
        => workflow.Concat(asyncEnumerable);

    public static IAsyncEnumerable<TEvent> ThenFromAsyncEnumerableFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<IAsyncEnumerable<TEvent>> createAsyncEnumerable)
        => ThenFromAsyncEnumerable(workflow, StartFromAsyncEnumerableFactory(createAsyncEnumerable));

    public static IAsyncEnumerable<TEvent> ThenFromAsyncEnumerableFactory1<TArg, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg arg)
        => ThenFromAsyncEnumerable(workflow, StartFromAsyncEnumerableFactory1(createAsyncEnumerable, arg));

    public static IAsyncEnumerable<TEvent> ThenFromAsyncEnumerableFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromAsyncEnumerableFactory2(createAsyncEnumerable, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromAsyncEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromAsyncEnumerableFactory3(createAsyncEnumerable, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerable<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        IEnumerable<TEvent> enumerable)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerable(enumerable));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerableFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<IEnumerable<TEvent>> createEnumerable)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory(createEnumerable));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerableFactory1<TArg, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg, IEnumerable<TEvent>> createEnumerable, TArg arg)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory1(createEnumerable, arg));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerableFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory2(createEnumerable, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory3(createEnumerable, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent> createEvent)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory(createEvent));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory1<TArg, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg, TEvent> createEvent, TArg arg)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory1(createEvent, arg));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TEvent> createEvent, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory2(createEvent, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, TEvent> createEvent, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory3(createEvent, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Task<TEvent> task)
        => ThenFromAsyncEnumerable(workflow, StartFromTask(task));

    public static IAsyncEnumerable<TEvent> ThenFromTaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<Task<TEvent>> createTask)
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory(createTask));

    public static IAsyncEnumerable<TEvent> ThenFromTaskFactory1<TArg, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg, Task<TEvent>> createTask, TArg arg)
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory1(createTask, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTaskFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory2(createTask, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory3(createTask, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromValueTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        ValueTask<TEvent> valueTask)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTask(valueTask));

    public static IAsyncEnumerable<TEvent> ThenFromValueTaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<ValueTask<TEvent>> createValueTask)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory(createValueTask));

    public static IAsyncEnumerable<TEvent> ThenFromValueTaskFactory1<TArg, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg, ValueTask<TEvent>> createValueTask, TArg arg)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory1(createValueTask, arg));

    public static IAsyncEnumerable<TEvent> ThenFromValueTaskFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory2(createValueTask, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromValueTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory3(createValueTask, arg1, arg2, arg3));
}