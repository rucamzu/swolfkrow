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

    public static Func<TEvent, Task<bool>> FromValueTaskPredicate<TEvent>(
        Func<TEvent, ValueTask<bool>> predicate)
        => FromTaskPredicate((TEvent @event) => predicate(@event).AsTask());

    public static Func<TEvent, Task<bool>> FromPredicate<TEvent>(
        Func<TEvent, bool> predicate)
        => FromTaskPredicate((TEvent @event) => Task.FromResult(predicate(@event)));
}

/// <summary>
/// Factory methods to build asynchronous predicates that take two events.
/// </summary>
internal static class Predicate2
{
    public static Task<bool> Always<TEvent1, TEvent2>(TEvent1 _, TEvent2 __)
    => Task.FromResult(true);

    public static Func<TEvent1, TEvent2, Task<bool>> FromTaskPredicate<TEvent1, TEvent2>(
        Func<TEvent1, TEvent2, Task<bool>> predicate)
        => predicate;

    public static Func<TEvent1, TEvent2, Task<bool>> FromValueTaskPredicate<TEvent1, TEvent2>(
        Func<TEvent1, TEvent2, ValueTask<bool>> predicate)
        => FromTaskPredicate((TEvent1 event1, TEvent2 event2) => predicate(event1, event2).AsTask());

    public static Func<TEvent1, TEvent2, Task<bool>> FromPredicate<TEvent1, TEvent2>(
        Func<TEvent1, TEvent2, bool> predicate)
        => FromTaskPredicate((TEvent1 event1, TEvent2 event2) => Task.FromResult(predicate(event1, event2)));
}
