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

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory4<TArg1, TArg2, TArg3, TArg4, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => StartFromAsyncEnumerableFactory(() => createAsyncEnumerable(arg1, arg2, arg3, arg4));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory5<TArg1, TArg2, TArg3, TArg4, TArg5, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, TArg5, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => StartFromAsyncEnumerableFactory(() => createAsyncEnumerable(arg1, arg2, arg3, arg4, arg5));

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

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory4<TArg1, TArg2, TArg3, TArg4, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => StartFromEnumerableFactory(() => createEnumerable(arg1, arg2, arg3, arg4));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory5<TArg1, TArg2, TArg3, TArg4, TArg5, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, TArg5, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => StartFromEnumerableFactory(() => createEnumerable(arg1, arg2, arg3, arg4, arg5));

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

    public static IAsyncEnumerable<TEvent> StartFromEventFactory4<TArg1, TArg2, TArg3, TArg4, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, TEvent> createEvent, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => StartFromEventFactory(() => createEvent(arg1, arg2, arg3, arg4));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory5<TArg1, TArg2, TArg3, TArg4, TArg5, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, TArg5, TEvent> createEvent, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => StartFromEventFactory(() => createEvent(arg1, arg2, arg3, arg4, arg5));

    public static IAsyncEnumerable<TEvent> StartFromTask<TEvent>(
        Task<TEvent> task)
        => task.ToAsyncEnumerable();

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory<TEvent>(
        Func<Task<TEvent>> createTask)
        => StartFromAsyncEnumerableFactory(() => StartFromTask(createTask()));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory1<TArg, TEvent>(
        Func<TArg, Task<TEvent>> createTask, TArg arg)
        => StartFromTaskFactory(() => createTask(arg));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2)
        => StartFromTaskFactory(() => createTask(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromTaskFactory(() => createTask(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory4<TArg1, TArg2, TArg3, TArg4, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => StartFromTaskFactory(() => createTask(arg1, arg2, arg3, arg4));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory5<TArg1, TArg2, TArg3, TArg4, TArg5, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, TArg5, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => StartFromTaskFactory(() => createTask(arg1, arg2, arg3, arg4, arg5));

    public static IAsyncEnumerable<TEvent> StartFromValueTask<TEvent>(
        ValueTask<TEvent> valueTask)
        => StartFromTask(valueTask.AsTask());

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory<TEvent>(
        Func<ValueTask<TEvent>> createValueTask)
        => StartFromAsyncEnumerableFactory(() => StartFromValueTask(createValueTask()));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory1<TArg, TEvent>(
        Func<TArg, ValueTask<TEvent>> createValueTask, TArg arg)
        => StartFromValueTaskFactory(() => createValueTask(arg));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2)
        => StartFromValueTaskFactory(() => createValueTask(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => StartFromValueTaskFactory(() => createValueTask(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory4<TArg1, TArg2, TArg3, TArg4, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => StartFromValueTaskFactory(() => createValueTask(arg1, arg2, arg3, arg4));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory5<TArg1, TArg2, TArg3, TArg4, TArg5, TEvent>(
        Func<TArg1, TArg2, TArg3, TArg4, TArg5, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => StartFromValueTaskFactory(() => createValueTask(arg1, arg2, arg3, arg4, arg5));

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

    public static async IAsyncEnumerable<TEvent> WhileFromPredicate<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, bool> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            if (!predicate(nextEvent))
                yield break;

            yield return nextEvent;
        }
    }

    public static async IAsyncEnumerable<TEvent> WhileFromTaskPredicate<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            if (!await predicate(nextEvent))
                yield break;

            yield return nextEvent;
        }
    }

    public static async IAsyncEnumerable<TEvent> WhileFromValueTaskPredicate<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, ValueTask<bool>> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            if (!await predicate(nextEvent))
                yield break;

            yield return nextEvent;
        }
    }

    public static async IAsyncEnumerable<TEvent> UntilFromPredicate<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, bool> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (predicate(nextEvent))
                yield break;
        }
    }

    public static async IAsyncEnumerable<TEvent> UntilFromTaskPredicate<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (await predicate(nextEvent))
                yield break;
        }
    }

    public static async IAsyncEnumerable<TEvent> UntilFromValueTaskPredicate<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, ValueTask<bool>> predicate)
    {
        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (await predicate(nextEvent))
                yield break;
        }
    }

    public static async IAsyncEnumerable<TEvent> ThenFromTriggered1AsyncEnumerableFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, IAsyncEnumerable<TEvent>> createContinuation)
        where TTriggerEvent : TEvent
    {
        EventCache1<TEvent, TTriggerEvent> cached = new();

        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (cached.Cache(nextEvent) && cached.IsCached && await predicate(cached.Event!))
                await foreach (var nextEvent_ in createContinuation(cached.Event!))
                    yield return nextEvent_;
        }
    }

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1AsyncEnumerableFactory1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg, IAsyncEnumerable<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory2(createContinuation, triggerEvent, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1AsyncEnumerableFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory3(createContinuation, triggerEvent, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1AsyncEnumerableFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory4(createContinuation, triggerEvent, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EnumerableFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, IEnumerable<TEvent>> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EnumerableFactory1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg, IEnumerable<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory2(createContinuation, triggerEvent, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EnumerableFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory3(createContinuation, triggerEvent, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EnumerableFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory4(createContinuation, triggerEvent, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EventFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TEvent> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EventFactory1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg, TEvent> createContinuation, TArg arg)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory2(createContinuation, triggerEvent, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EventFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TEvent> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory3(createContinuation, triggerEvent, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EventFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, TEvent> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory4(createContinuation, triggerEvent, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1TaskFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, Task<TEvent>> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1TaskFactory1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg, Task<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory2(createContinuation, triggerEvent, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1TaskFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory3(createContinuation, triggerEvent, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1TaskFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory4(createContinuation, triggerEvent, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1ValueTaskFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, ValueTask<TEvent>> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1ValueTaskFactory1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg, ValueTask<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory2(createContinuation, triggerEvent, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1ValueTaskFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory3(createContinuation, triggerEvent, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1ValueTaskFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory4(createContinuation, triggerEvent, arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> ThenFromTriggered2AsyncEnumerableFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, IAsyncEnumerable<TEvent>> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
    {
        EventCache2<TEvent, TTriggerEvent1, TTriggerEvent2> cached = new();

        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (cached.Cache(nextEvent) && cached.IsCached && await predicate(cached.Event1!, cached.Event2!))
                await foreach (var nextEvent_ in createContinuation(cached.Event1!, cached.Event2!))
                    yield return nextEvent_;
        }
    }

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2AsyncEnumerableFactory1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg, IAsyncEnumerable<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromAsyncEnumerableFactory3(createContinuation, triggerEvent1, triggerEvent2, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2AsyncEnumerableFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromAsyncEnumerableFactory4(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2AsyncEnumerableFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromAsyncEnumerableFactory5(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EnumerableFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, IEnumerable<TEvent>> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EnumerableFactory1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg, IEnumerable<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory3(createContinuation, triggerEvent1, triggerEvent2, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EnumerableFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory4(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EnumerableFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory5(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EventFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TEvent> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEventFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EventFactory1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg, TEvent> createContinuation, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEventFactory3(createContinuation, triggerEvent1, triggerEvent2, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EventFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TEvent> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEventFactory4(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EventFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, TEvent> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEventFactory5(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2TaskFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, Task<TEvent>> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2TaskFactory1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg, Task<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory3(createContinuation, triggerEvent1, triggerEvent2, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2TaskFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory4(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2TaskFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory5(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2ValueTaskFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, ValueTask<TEvent>> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2ValueTaskFactory1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg, ValueTask<TEvent>> createContinuation, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory3(createContinuation, triggerEvent1, triggerEvent2, arg));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2ValueTaskFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory4(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2ValueTaskFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory5(createContinuation, triggerEvent1, triggerEvent2, arg1, arg2, arg3));
}