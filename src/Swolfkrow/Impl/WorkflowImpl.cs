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

    public static IAsyncEnumerable<TEvent> ThenFromEnumerable<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        IEnumerable<TEvent> enumerable)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerable(enumerable));

    public static IAsyncEnumerable<TEvent> ThenFromEnumerableFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<IEnumerable<TEvent>> createEnumerable)
        => ThenFromAsyncEnumerable(workflow, StartFromEnumerableFactory(createEnumerable));

    public static IAsyncEnumerable<TEvent> ThenFromEventFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent> createEvent)
        => ThenFromAsyncEnumerable(workflow, StartFromEventFactory(createEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Task<TEvent> task)
        => ThenFromAsyncEnumerable(workflow, StartFromTask(task));

    public static IAsyncEnumerable<TEvent> ThenFromTaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<Task<TEvent>> createTask)
        => ThenFromAsyncEnumerable(workflow, StartFromTaskFactory(createTask));

    public static IAsyncEnumerable<TEvent> ThenFromValueTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        ValueTask<TEvent> valueTask)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTask(valueTask));

    public static IAsyncEnumerable<TEvent> ThenFromValueTaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<ValueTask<TEvent>> createValueTask)
        => ThenFromAsyncEnumerable(workflow, StartFromValueTaskFactory(createValueTask));

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

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EnumerableFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, IEnumerable<TEvent>> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0EventFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, TEvent> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0TaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, Task<TEvent>> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered0ValueTaskFactory<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task<bool>> predicate,
        Func<TEvent, ValueTask<TEvent>> createContinuation)
        => ThenFromTriggered0AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation, triggerEvent));

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

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EnumerableFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, IEnumerable<TEvent>> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEnumerableFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1EventFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, TEvent> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromEventFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1TaskFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, Task<TEvent>> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromTaskFactory1(createContinuation, triggerEvent));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered1ValueTaskFactory<TEvent, TTriggerEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent, Task<bool>> predicate,
        Func<TTriggerEvent, ValueTask<TEvent>> createContinuation)
        where TTriggerEvent : TEvent
        => ThenFromTriggered1AsyncEnumerableFactory(workflow, predicate,
            triggerEvent => StartFromValueTaskFactory1(createContinuation, triggerEvent));

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

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EnumerableFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, IEnumerable<TEvent>> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEnumerableFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2EventFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, TEvent> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromEventFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2TaskFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, Task<TEvent>> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromTaskFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> ThenFromTriggered2ValueTaskFactory<TEvent, TTriggerEvent1, TTriggerEvent2>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TTriggerEvent1, TTriggerEvent2, Task<bool>> predicate,
        Func<TTriggerEvent1, TTriggerEvent2, ValueTask<TEvent>> createContinuation)
        where TTriggerEvent1 : TEvent
        where TTriggerEvent2 : TEvent
        => ThenFromTriggered2AsyncEnumerableFactory(workflow, predicate,
            (triggerEvent1, triggerEvent2) => StartFromValueTaskFactory2(createContinuation, triggerEvent1, triggerEvent2));

    public static IAsyncEnumerable<TEvent> DoFromAction<TEvent>(
        IAsyncEnumerable<TEvent> workflow, Action<TEvent> effect)
        => workflow.Select(nextEvent => { effect(nextEvent); return nextEvent; });

    public static IAsyncEnumerable<TEvent> DoFromTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow,
        Func<TEvent, Task> effect)
        => workflow.SelectAwait(async nextEvent => { await effect(nextEvent); return nextEvent; });

    public static IAsyncEnumerable<TEvent> DoFromValueTask<TEvent>(
        IAsyncEnumerable<TEvent> workflow, Func<TEvent, ValueTask> effect)
        => workflow.SelectAwait(async nextEvent => { await effect(nextEvent); return nextEvent; });

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