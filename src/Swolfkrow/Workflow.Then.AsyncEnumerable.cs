﻿using Swolfkrow.Impl;

namespace Swolfkrow;

public partial class Workflow<TEvent>
{
    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with a second asynchronous workflow. 
    /// </summary>
    /// <param name="continuation">An asynchronous workflow.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the given <paramref name="continuation"/>.</returns>
    public Workflow<TEvent> Then(
        IAsyncEnumerable<TEvent> continuation)
        => WorkflowImpl.ThenFromAsyncEnumerable(_workflow, continuation).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with an asynchronous workflow factory. 
    /// </summary>
    /// <param name="createContinuation">A factory that returns an asynchronous workflow.</param>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory.</returns>
    public Workflow<TEvent> Then(
        Func<IAsyncEnumerable<TEvent>> createContinuation)
        => WorkflowImpl.ThenFromAsyncEnumerableFactory(_workflow, createContinuation).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with an asynchronous workflow factory that takes one argument.
    /// </summary>
    /// <param name="createContinuation">A factory that takes one argument and returns an asynchronous workflow.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the given <paramref name="arg"/>ument.</returns>
    public Workflow<TEvent> Then<TArg>(
        Func<TArg, IAsyncEnumerable<TEvent>> createContinuation, TArg arg)
        => WorkflowImpl.ThenFromAsyncEnumerableFactory1(_workflow, createContinuation, arg).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with an asynchronous workflow factory that takes two arguments. 
    /// </summary>
    /// <param name="createContinuation">A factory that takes two arguments and returns an asynchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the given arguments.</returns>
    public Workflow<TEvent> Then<TArg1, TArg2>(
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.ThenFromAsyncEnumerableFactory2(_workflow, createContinuation, arg1, arg2).ToWorkflow();

    /// <summary>
    /// Continues the asynchronous <see cref="Workflow{TEvent}"/> with an asynchronous workflow factory that takes three arguments. 
    /// </summary>
    /// <param name="createContinuation">A factory that takes three arguments and returns an asynchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createContinuation"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createContinuation"/> factory.</typeparam>
    /// <returns>A new asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by <see langword="this"/> asynchronous workflow, followed by the events yielded by the asynchronous workflow returned by calling the given <paramref name="createContinuation"/> factory with the given arguments.</returns>
    public Workflow<TEvent> Then<TArg1, TArg2, TArg3>(
        Func<TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createContinuation, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.ThenFromAsyncEnumerableFactory3(_workflow, createContinuation, arg1, arg2, arg3).ToWorkflow();
}
