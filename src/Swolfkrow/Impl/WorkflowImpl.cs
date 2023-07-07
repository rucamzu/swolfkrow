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
        => StartFromAsyncEnumerableFactory(createAsyncEnumerable.BindAll(arg));

    public static IAsyncEnumerable<TEvent> StartFromAsyncEnumerableFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2)
        => StartFromAsyncEnumerableFactory(createAsyncEnumerable.BindAll(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromEnumerable<TEvent>(
        IEnumerable<TEvent> enumerable)
        => enumerable.ToAsyncEnumerable();

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory<TEvent>(
        Func<IEnumerable<TEvent>> createEnumerable)
        => StartFromAsyncEnumerableFactory(() => StartFromEnumerable(createEnumerable()));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory1<TArg, TEvent>(
        Func<TArg, IEnumerable<TEvent>> createEnumerable, TArg arg)
        => StartFromEnumerableFactory(createEnumerable.BindAll(arg));

    public static IAsyncEnumerable<TEvent> StartFromEnumerableFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2)
        => StartFromEnumerableFactory(createEnumerable.BindAll(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory<TEvent>(
        Func<TEvent> createEvent)
        => StartFromEnumerableFactory(() => Enumerable.Repeat(createEvent(), 1));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory1<TArg, TEvent>(
        Func<TArg, TEvent> createEvent, TArg arg)
        => StartFromEventFactory(createEvent.BindAll(arg));

    public static IAsyncEnumerable<TEvent> StartFromEventFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, TEvent> createEvent, TArg1 arg1, TArg2 arg2)
        => StartFromEventFactory(createEvent.BindAll(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromTask<TEvent>(
        Task<TEvent> task)
        => task.ToAsyncEnumerable();

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory<TEvent>(
        Func<Task<TEvent>> createTask)
        => StartFromAsyncEnumerableFactory(() => StartFromTask(createTask()));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory1<TArg, TEvent>(
        Func<TArg, Task<TEvent>> createTask, TArg arg)
        => StartFromTaskFactory(createTask.BindAll(arg));

    public static IAsyncEnumerable<TEvent> StartFromTaskFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2)
        => StartFromTaskFactory(createTask.BindAll(arg1, arg2));

    public static IAsyncEnumerable<TEvent> StartFromValueTask<TEvent>(
        ValueTask<TEvent> valueTask)
        => StartFromTask(valueTask.AsTask());

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory<TEvent>(
        Func<ValueTask<TEvent>> createValueTask)
        => StartFromAsyncEnumerableFactory(() => StartFromValueTask(createValueTask()));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory1<TArg, TEvent>(
        Func<TArg, ValueTask<TEvent>> createValueTask, TArg arg)
        => StartFromValueTaskFactory(createValueTask.BindAll(arg));

    public static IAsyncEnumerable<TEvent> StartFromValueTaskFactory2<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2)
        => StartFromValueTaskFactory(createValueTask.BindAll(arg1, arg2));

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
        => ThenFromAsyncEnumerable(workflow, StartFromAsyncEnumerableFactory(createAsyncEnumerable.BindAll(arg)));

    public static IAsyncEnumerable<TEvent> ThenFromAsyncEnumerableFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromAsyncEnumerableFactory(createAsyncEnumerable.BindAll(arg1, arg2)));

    public static IAsyncEnumerable<TEvent> ThenFromAsyncEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createAsyncEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromAsyncEnumerableFactory(createAsyncEnumerable.BindAll(arg1, arg2, arg3)));

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
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory(createEnumerable.BindAll(arg)));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerableFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory(createEnumerable.BindAll(arg1, arg2)));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerableFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, IEnumerable<TEvent>> createEnumerable, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory(createEnumerable.BindAll(arg1, arg2, arg3)));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent> createEvent)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory(createEvent));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory1<TArg, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg, TEvent> createEvent, TArg arg)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory(createEvent.BindAll(arg)));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TEvent> createEvent, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory(createEvent.BindAll(arg1, arg2)));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, TEvent> createEvent, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory(createEvent.BindAll(arg1, arg2, arg3)));

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
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory(createTask.BindAll(arg)));

    public static IAsyncEnumerable<TEvent> ThenFromTaskFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory(createTask.BindAll(arg1, arg2)));

    public static IAsyncEnumerable<TEvent> ThenFromTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, Task<TEvent>> createTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory(createTask.BindAll(arg1, arg2, arg3)));

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
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory(createValueTask.BindAll(arg)));

    public static IAsyncEnumerable<TEvent> ThenFromValueTaskFactory2<TArg1, TArg2, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory(createValueTask.BindAll(arg1, arg2)));

    public static IAsyncEnumerable<TEvent> ThenFromValueTaskFactory3<TArg1, TArg2, TArg3, TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TArg1, TArg2, TArg3, ValueTask<TEvent>> createValueTask, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory(createValueTask.BindAll(arg1, arg2, arg3)));

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

    public static async IAsyncEnumerable<TEvent> ThenFromTriggered0AsyncEnumerableFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, IAsyncEnumerable<TEvent>> createContinuation)
    {
        EventCache1<TEvent> cached = new();

        await foreach (var nextEvent in workflow)
        {
            yield return nextEvent;

            if (cached.Cache(nextEvent) && cached.IsCached && await predicate(cached.Event!))
                await foreach (var nextEvent_ in createContinuation(cached.Event!))
                    yield return nextEvent_;
        }
    }

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0AsyncEnumerableFactory1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg, IAsyncEnumerable<TEvent>> createContinuation, TArg arg)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0AsyncEnumerableFactory2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0AsyncEnumerableFactory3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EnumerableFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, IEnumerable<TEvent>> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EnumerableFactory1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg, IEnumerable<TEvent>> createContinuation, TArg arg)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EnumerableFactory2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EnumerableFactory3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EventFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TEvent> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EventFactory1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg, TEvent> createContinuation, TArg arg)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EventFactory2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TEvent> createContinuation, TArg1 arg1, TArg2 arg2)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EventFactory3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TArg3, TEvent> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0TaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, Task<TEvent>> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0TaskFactory1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg, Task<TEvent>> createContinuation, TArg arg)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0TaskFactory2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0TaskFactory3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TArg3, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0ValueTaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, ValueTask<TEvent>> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0ValueTaskFactory1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg, ValueTask<TEvent>> createContinuation, TArg arg)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0ValueTaskFactory2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0ValueTaskFactory3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

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
            triggerEvent => StartFromAsyncEnumerableFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1AsyncEnumerableFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1AsyncEnumerableFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromAsyncEnumerableFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

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
            triggerEvent => StartFromEnumerableFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EnumerableFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EnumerableFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

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
            triggerEvent => StartFromEventFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EventFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TEvent> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EventFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, TEvent> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

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
            triggerEvent => StartFromTaskFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1TaskFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1TaskFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

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
            triggerEvent => StartFromValueTaskFactory1(createContinuation.BindLast(arg), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1ValueTaskFactory2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation.BindLast(arg1, arg2), triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1ValueTaskFactory3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent));

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
            (triggerEvent1, triggerEvent2) => StartFromAsyncEnumerableFactory2(createContinuation.BindLast(arg), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2AsyncEnumerableFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromAsyncEnumerableFactory2(createContinuation.BindLast(arg1, arg2), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2AsyncEnumerableFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromAsyncEnumerableFactory2(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent1, triggerEvent2));

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
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory2(createContinuation.BindLast(arg), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EnumerableFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory2(createContinuation.BindLast(arg1, arg2), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EnumerableFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, IEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory2(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent1, triggerEvent2));

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
            (triggerEvent1, triggerEvent2) => StartFromEventFactory2(createContinuation.BindLast(arg), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EventFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TEvent> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEventFactory2(createContinuation.BindLast(arg1, arg2), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EventFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, TEvent> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEventFactory2(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent1, triggerEvent2));

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
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory2(createContinuation.BindLast(arg), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2TaskFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory2(createContinuation.BindLast(arg1, arg2), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2TaskFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, Task<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory2(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent1, triggerEvent2));

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
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory2(createContinuation.BindLast(arg), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2ValueTaskFactory2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory2(createContinuation.BindLast(arg1, arg2), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2ValueTaskFactory3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, ValueTask<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
       => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory2(createContinuation.BindLast(arg1, arg2, arg3), triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> DoFromAction<TEvent>(
        IAsyncEnumerable<TEvent> workflow, Action<TEvent> effect)
        => workflow.Select(nextEvent => { effect(nextEvent); return nextEvent; });

    public static IAsyncEnumerable<TEvent> DoFromAction1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow, Action<TEvent, TArg> effect, TArg arg)
        => DoFromAction(workflow, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromAction2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow, Action<TEvent, TArg1, TArg2> effect, TArg1 arg1, TArg2 arg2)
        => DoFromAction(workflow, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromAction3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow, Action<TEvent, TArg1, TArg2, TArg3> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromAction(workflow, effect.BindLast(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> DoFromTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task> effect)
        => workflow.SelectAwait(async nextEvent => { await effect(nextEvent); return nextEvent; });

    public static IAsyncEnumerable<TEvent> DoFromTask1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, TArg, Task> effect, TArg arg)
        => DoFromTask(workflow, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTask2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, TArg1, TArg2, Task> effect, TArg1 arg1, TArg2 arg2)
        => DoFromTask(workflow, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTask3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, TArg1, TArg2, TArg3, Task> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromTask(workflow, effect.BindLast(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> DoFromValueTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow, Func<TEvent, ValueTask> effect)
        => workflow.SelectAwait(async nextEvent => { await effect(nextEvent); return nextEvent; });

    public static IAsyncEnumerable<TEvent> DoFromValueTask1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, TArg, ValueTask> effect, TArg arg)
        => DoFromValueTask(workflow, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromValueTask2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, TArg1, TArg2, ValueTask> effect, TArg1 arg1, TArg2 arg2)
        => DoFromValueTask(workflow, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromValueTask3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, TArg1, TArg2, TArg3, ValueTask> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromValueTask(workflow, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered0Action<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Action<TEvent> effect)
    {
        await foreach (var nextEvent in workflow)
        {
            if (await predicate(nextEvent))
                effect(nextEvent);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered0Action1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Action<TEvent, TArg> effect, TArg arg)
        => DoFromTriggered0Action(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered0Action2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Action<TEvent, TArg1, TArg2> effect, TArg1 arg1, TArg2 arg2)
        => DoFromTriggered0Action(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered0Action3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Action<TEvent, TArg1, TArg2, TArg3> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromTriggered0Action(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered0Task<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, Task> effect)
    {
        await foreach (var nextEvent in workflow)
        {
            if (await predicate(nextEvent))
                await effect(nextEvent);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered0Task1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg, Task> effect, TArg arg)
        => DoFromTriggered0Task(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered0Task2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, Task> effect, TArg1 arg1, TArg2 arg2)
        => DoFromTriggered0Task(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered0Task3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TArg3, Task> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromTriggered0Task(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered0ValueTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, ValueTask> effect)
    {
        await foreach (var nextEvent in workflow)
        {
            if (await predicate(nextEvent))
                await effect(nextEvent);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered0ValueTask1<TEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg, ValueTask> effect, TArg arg)
        => DoFromTriggered0ValueTask(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered0ValueTask2<TEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, ValueTask> effect, TArg1 arg1, TArg2 arg2)
        => DoFromTriggered0ValueTask(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered0ValueTask3<TEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TArg1, TArg2, TArg3, ValueTask> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromTriggered0ValueTask(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered1Action<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Action<TTriggerEvent> effect)
    {
        await foreach (var nextEvent in workflow)
        {
            if (nextEvent is TTriggerEvent triggerEvent && await predicate(triggerEvent))
                effect(triggerEvent);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered1Action1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Action<TTriggerEvent, TArg> effect, TArg arg)
        => DoFromTriggered1Action(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered1Action2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Action<TTriggerEvent, TArg1, TArg2> effect, TArg1 arg1, TArg2 arg2)
        => DoFromTriggered1Action(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered1Action3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Action<TTriggerEvent, TArg1, TArg2, TArg3> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromTriggered1Action(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered1Task<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, Task> effect)
    {
        await foreach (var nextEvent in workflow)
        {
            if (nextEvent is TTriggerEvent triggerEvent && await predicate(triggerEvent))
                await effect(triggerEvent);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered1Task1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg, Task> effect, TArg arg)
        => DoFromTriggered1Task(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered1Task2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, Task> effect, TArg1 arg1, TArg2 arg2)
        => DoFromTriggered1Task(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered1Task3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, Task> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromTriggered1Task(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered1ValueTask<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, ValueTask> effect)
    {
        await foreach (var nextEvent in workflow)
        {
            if (nextEvent is TTriggerEvent triggerEvent && await predicate(triggerEvent))
                await effect(triggerEvent);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered1ValueTask1<TEvent, TTriggerEvent, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg, ValueTask> effect, TArg arg)
        => DoFromTriggered1ValueTask(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered1ValueTask2<TEvent, TTriggerEvent, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, ValueTask> effect, TArg1 arg1, TArg2 arg2)
        => DoFromTriggered1ValueTask(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered1ValueTask3<TEvent, TTriggerEvent, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TArg1, TArg2, TArg3, ValueTask> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => DoFromTriggered1ValueTask(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered2Action<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Action<TTriggerEvent1, TTriggerEvent2> effect)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
    {
        EventCache2<TEvent, TTriggerEvent1, TTriggerEvent2> cached = new();

        await foreach (var nextEvent in workflow)
        {
            if (cached.Cache(nextEvent) && cached.IsCached && await predicate(cached.Event1!, cached.Event2!))
                effect(cached.Event1!, cached.Event2!);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered2Action1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Action<TTriggerEvent1, TTriggerEvent2, TArg> effect, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2Action(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered2Action2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Action<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2> effect, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2Action(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered2Action3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Action<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2Action(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered2Task<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, Task> effect)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
    {
        EventCache2<TEvent, TTriggerEvent1, TTriggerEvent2> cached = new();

        await foreach (var nextEvent in workflow)
        {
            if (cached.Cache(nextEvent) && cached.IsCached && await predicate(cached.Event1!, cached.Event2!))
                await effect(cached.Event1!, cached.Event2!);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered2Task1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg, Task> effect, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2Task(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered2Task2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, Task> effect, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2Task(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered2Task3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, Task> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2Task(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static async IAsyncEnumerable<TEvent> DoFromTriggered2ValueTask<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, ValueTask> effect)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
    {
        EventCache2<TEvent, TTriggerEvent1, TTriggerEvent2> cached = new();

        await foreach (var nextEvent in workflow)
        {
            if (cached.Cache(nextEvent) && cached.IsCached && await predicate(cached.Event1!, cached.Event2!))
                await effect(cached.Event1!, cached.Event2!);

            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> DoFromTriggered2ValueTask1<TEvent, TTriggerEvent1, TTriggerEvent2, TArg>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg, ValueTask> effect, TArg arg)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2ValueTask(workflow, predicate, effect.BindLast(arg));

    public static IAsyncEnumerable<TEvent> DoFromTriggered2ValueTask2<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, ValueTask> effect, TArg1 arg1, TArg2 arg2)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2ValueTask(workflow, predicate, effect.BindLast(arg1, arg2));

    public static IAsyncEnumerable<TEvent> DoFromTriggered2ValueTask3<TEvent, TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TArg1, TArg2, TArg3, ValueTask> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => DoFromTriggered2ValueTask(workflow, predicate, effect.BindLast(arg1, arg2, arg3));

    public static IAsyncEnumerable<TEvent> ThenWithStateFromFactory<TEvent, TState>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, TState> computeNextState,
        TState initialState)
        => ThenWithStateFromTaskFactory(
            workflow,
            createContinuation,
            (state, nextEvent) => Task.FromResult(computeNextState(state, nextEvent)),
            initialState);

    public static async IAsyncEnumerable<TEvent> ThenWithStateFromTaskFactory<TEvent, TState>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, Task<TState>> computeNextState,
        TState initialState)
    {
        TState currentState = initialState;

        await foreach (var nextEvent in workflow)
        {
            currentState = await computeNextState(currentState, nextEvent);

            yield return nextEvent;
        }

        await foreach (var nextEvent in createContinuation(currentState))
        {
            yield return nextEvent;
        }
    }

    public static IAsyncEnumerable<TEvent> ThenWithStateFromValueTaskFactory<TEvent, TState>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TState, IAsyncEnumerable<TEvent>> createContinuation,
        Func<TState, TEvent, ValueTask<TState>> computeNextState,
        TState initialState)
        => ThenWithStateFromTaskFactory(
            workflow,
            createContinuation,
            (state, nextEvent) => computeNextState(state, nextEvent).AsTask(),
            initialState);
}