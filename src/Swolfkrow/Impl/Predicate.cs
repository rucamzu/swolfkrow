namespace Swolfkrow.Impl;

/// <summary>
/// Factory methods to build asynchronous predicates that take one event.
/// </summary>
internal static class Predicate1
{
    public static Task<bool> Always<TEvent>(TEvent _)
        => Task.FromResult(true);

    public static Func<TEvent, Task<bool>> FromTaskPredicate<TEvent>(
        Func<TEvent, Task<bool>> predicate)
        => predicate;

    public static Func<TEvent, Task<bool>> FromTaskPredicate1<TEvent, TArg>(
        Func<TEvent, TArg, Task<bool>> predicate, TArg arg)
        => FromTaskPredicate((TEvent @event) => predicate(@event, arg));

    public static Func<TEvent, Task<bool>> FromTaskPredicate2<TEvent, TArg1, TArg2>(
        Func<TEvent, TArg1, TArg2, Task<bool>> predicate, TArg1 arg1, TArg2 arg2)
        => FromTaskPredicate((TEvent @event) => predicate(@event, arg1, arg2));

    public static Func<TEvent, Task<bool>> FromTaskPredicate3<TEvent, TArg1, TArg2, TArg3>(
        Func<TEvent, TArg1, TArg2, TArg3, Task<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => FromTaskPredicate((TEvent @event) => predicate(@event, arg1, arg2, arg3));

    public static Func<TEvent, Task<bool>> FromValueTaskPredicate<TEvent>(
        Func<TEvent, ValueTask<bool>> predicate)
        => FromTaskPredicate((TEvent @event) => predicate(@event).AsTask());

    public static Func<TEvent, Task<bool>> FromValueTaskPredicate1<TEvent, TArg>(
        Func<TEvent, TArg, ValueTask<bool>> predicate, TArg arg)
        => FromValueTaskPredicate((TEvent @event) => predicate(@event, arg));

    public static Func<TEvent, Task<bool>> FromValueTaskPredicate2<TEvent, TArg1, TArg2>(
        Func<TEvent, TArg1, TArg2, ValueTask<bool>> predicate, TArg1 arg1, TArg2 arg2)
        => FromValueTaskPredicate((TEvent @event) => predicate(@event, arg1, arg2));

    public static Func<TEvent, Task<bool>> FromValueTaskPredicate3<TEvent, TArg1, TArg2, TArg3>(
        Func<TEvent, TArg1, TArg2, TArg3, ValueTask<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => FromValueTaskPredicate((TEvent @event) => predicate(@event, arg1, arg2, arg3));

    public static Func<TEvent, Task<bool>> FromPredicate<TEvent>(
        Func<TEvent, bool> predicate)
        => FromTaskPredicate((TEvent @event) => Task.FromResult(predicate(@event)));

    public static Func<TEvent, Task<bool>> FromPredicate1<TEvent, TArg>(
        Func<TEvent, TArg, bool> predicate, TArg arg)
        => FromPredicate((TEvent @event) => predicate(@event, arg));

    public static Func<TEvent, Task<bool>> FromPredicate2<TEvent, TArg1, TArg2>(
        Func<TEvent, TArg1, TArg2, bool> predicate, TArg1 arg1, TArg2 arg2)
        => FromPredicate((TEvent @event) => predicate(@event, arg1, arg2));

    public static Func<TEvent, Task<bool>> FromPredicate3<TEvent, TArg1, TArg2, TArg3>(
        Func<TEvent, TArg1, TArg2, TArg3, bool> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => FromPredicate((TEvent @event) => predicate(@event, arg1, arg2, arg3));
}

/// <summary>
/// Factory methods to build asynchronous predicates that take two events.
/// </summary>
internal static class Predicate2
{
    public static Func<TEvent1, TEvent2, Task<bool>> FromTaskPredicate<TEvent1, TEvent2>(
        Func<TEvent1, TEvent2, Task<bool>> predicate)
        => predicate;

    public static Func<TEvent1, TEvent2, Task<bool>> FromTaskPredicate1<TEvent1, TEvent2, TArg>(
        Func<TEvent1, TEvent2, TArg, Task<bool>> predicate, TArg arg)
        => FromTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg));

    public static Func<TEvent1, TEvent2, Task<bool>> FromTaskPredicate2<TEvent1, TEvent2, TArg1, TArg2>(
        Func<TEvent1, TEvent2, TArg1, TArg2, Task<bool>> predicate, TArg1 arg1, TArg2 arg2)
        => FromTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg1, arg2));

    public static Func<TEvent1, TEvent2, Task<bool>> FromTaskPredicate3<TEvent1, TEvent2, TArg1, TArg2, TArg3>(
        Func<TEvent1, TEvent2, TArg1, TArg2, TArg3, Task<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => FromTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg1, arg2, arg3));

    public static Func<TEvent1, TEvent2, Task<bool>> FromValueTaskPredicate<TEvent1, TEvent2>(
        Func<TEvent1, TEvent2, ValueTask<bool>> predicate)
        => FromTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2).AsTask());

    public static Func<TEvent1, TEvent2, Task<bool>> FromValueTaskPredicate1<TEvent1, TEvent2, TArg>(
        Func<TEvent1, TEvent2, TArg, ValueTask<bool>> predicate, TArg arg)
        => FromValueTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg));

    public static Func<TEvent1, TEvent2, Task<bool>> FromValueTaskPredicate2<TEvent1, TEvent2, TArg1, TArg2>(
        Func<TEvent1, TEvent2, TArg1, TArg2, ValueTask<bool>> predicate, TArg1 arg1, TArg2 arg2)
        => FromValueTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg1, arg2));

    public static Func<TEvent1, TEvent2, Task<bool>> FromValueTaskPredicate3<TEvent1, TEvent2, TArg1, TArg2, TArg3>(
        Func<TEvent1, TEvent2, TArg1, TArg2, TArg3, ValueTask<bool>> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => FromValueTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg1, arg2, arg3));

    public static Func<TEvent1, TEvent2, Task<bool>> FromPredicate<TEvent1, TEvent2>(
        Func<TEvent1, TEvent2, bool> predicate)
        => FromTaskPredicate((TEvent1 event1, TEvent2 event2) => Task.FromResult(predicate(event1, event2)));

    public static Func<TEvent1, TEvent2, Task<bool>> FromPredicate1<TEvent1, TEvent2, TArg>(
        Func<TEvent1, TEvent2, TArg, bool> predicate, TArg arg)
        => FromPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg));

    public static Func<TEvent1, TEvent2, Task<bool>> FromPredicate2<TEvent1, TEvent2, TArg1, TArg2>(
        Func<TEvent1, TEvent2, TArg1, TArg2, bool> predicate, TArg1 arg1, TArg2 arg2)
        => FromPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg1, arg2));

    public static Func<TEvent1, TEvent2, Task<bool>> FromPredicate3<TEvent1, TEvent2, TArg1, TArg2, TArg3>(
        Func<TEvent1, TEvent2, TArg1, TArg2, TArg3, bool> predicate, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => FromPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2, arg1, arg2, arg3));
}
