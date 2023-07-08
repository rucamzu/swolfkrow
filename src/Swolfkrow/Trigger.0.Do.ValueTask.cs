using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Trigger<TEvent>
{
    /// <summary>
    /// Injects an asynchronous side effect executed on every yielded triggering event.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/>.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Do(
        Func<TEvent, ValueTask> effect)
        => WorkflowImpl.DoFromTriggered0ValueTask(
            _workflow, _predicate, effect).ToWorkflow();

    /// <summary>
    /// Injects an asynchronous side effect executed on every yielded triggering event.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/> and one additional argument.</param>
    /// <param name="arg">The argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Do<TArg>(
        Func<TEvent, TArg, ValueTask> effect, TArg arg)
        => WorkflowImpl.DoFromTriggered0ValueTask(_workflow, _predicate, effect.BindLast(arg)).ToWorkflow();

    /// <summary>
    /// Injects an asynchronous side effect executed on every yielded triggering event.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/> and two additional arguments.</param>
    /// <param name="arg1">The first argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <param name="arg2">The second argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Do<TArg1, TArg2>(
        Func<TEvent, TArg1, TArg2, ValueTask> effect, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.DoFromTriggered0ValueTask(_workflow, _predicate, effect.BindLast(arg1, arg2)).ToWorkflow();

    /// <summary>
    /// Injects an asynchronous side effect executed on every yielded triggering event.
    /// </summary>
    /// <param name="effect">A function encapsulating an asynchronous side effect that takes an event of type <typeparamref name="TEvent"/> and three additional arguments.</param>
    /// <param name="arg1">The first argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <param name="arg2">The second argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <param name="arg3">The third argument passed to the given asynchronous side <paramref name="effect"/>.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given asynchronous side <paramref name="effect"/>.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields all the events yielded by the original, after executing the given asynchronous side <paramref name="effect"/> on each yielded triggering event.</returns>
    /// <remarks>The triggering events are those that satisfy the triggering condition defined by the preceeding 'When' operator.</remarks>
    public Workflow<TEvent> Do<TArg1, TArg2, TArg3>(
        Func<TEvent, TArg1, TArg2, TArg3, ValueTask> effect, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.DoFromTriggered0ValueTask(_workflow, _predicate, effect.BindLast(arg1, arg2, arg3)).ToWorkflow();
}
