﻿using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Injects an asynchronous side effect into an asynchronous workflow.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/> and returns a <see cref="ValueTask"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded event.</returns>
    public IAsyncEnumerable<TEvent> Do(Func<TEvent, ValueTask> effect)
        => WorkflowImpl.DoFromValueTask(_workflow, effect).ToWorkflow();

    /// <summary>
    /// Injects an asynchronous side effect executed on every yielded event.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/> and one additional argument, and returns a <see cref="ValueTask"/>.</param>
    /// <param name="arg">The argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded event.</returns>
    public IAsyncEnumerable<TEvent> Do<TArg>(
        Func<TEvent, TArg, ValueTask> effect, TArg arg)
        => WorkflowImpl.DoFromValueTask1(_workflow, effect, arg).ToWorkflow();

    /// <summary>
    /// Injects an asynchronous side effect executed on every yielded event.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/> and two additional arguments, and returns a <see cref="ValueTask"/>.</param>
    /// <param name="arg1">The first argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <param name="arg2">The second argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded event.</returns>
    public IAsyncEnumerable<TEvent> Do<TArg1, TArg2>(
        Func<TEvent, TArg1, TArg2, ValueTask> effect, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.DoFromValueTask2(_workflow, effect, arg1, arg2).ToWorkflow();

    /// <summary>
    /// Injects an asynchronous side effect executed on every yielded event.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/> and three additional arguments, and returns a <see cref="ValueTask"/>.</param>
    /// <param name="arg1">The first argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <param name="arg2">The second argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <param name="arg3">The third argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded event.</returns>
    public IAsyncEnumerable<TEvent> Do<TArg1, TArg2, TArg3>(
        Func<TEvent, TArg1, TArg2, TArg3, ValueTask> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.DoFromValueTask3(_workflow, effect, arg1, arg2, arg3).ToWorkflow();
}
