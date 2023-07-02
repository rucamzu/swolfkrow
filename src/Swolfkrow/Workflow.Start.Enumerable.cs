using Swolfkrow.Impl;

namespace Swolfkrow;

public static partial class Workflow
{
    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> that yields a given sequence of <paramref name="events"/>.
    /// </summary>
    /// <param name="events">A sequence of events.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the given <paramref name="events"/> in order.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(params TEvent[] events)
        => WorkflowImpl.StartFromEnumerable((IEnumerable<TEvent>)events).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a synchronous workflow.
    /// </summary>
    /// <param name="workflow">A synchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the events yielded by the given synchronous <paramref name="workflow"/> in order.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(IEnumerable<TEvent> workflow)
        => WorkflowImpl.StartFromEnumerable(workflow).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a synchronous workflow factory.
    /// </summary>
    /// <param name="createWorkflow">A factory that returns a synchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory and yields the events yielded by the resulting synchronous workflow in order.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(Func<IEnumerable<TEvent>> createWorkflow)
        => WorkflowImpl.StartFromEnumerableFactory(createWorkflow).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a synchronous workflow factory that takes one argument.
    /// </summary>
    /// <param name="createWorkflow">A factory that takes one argument and returns a synchronous workflow.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory with the given <paramref name="arg"/>ument and yields the events yielded by the resulting synchronous workflow in order.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg, TEvent>(
        Func<TArg, IEnumerable<TEvent>> createWorkflow, TArg arg)
        => WorkflowImpl.StartFromEnumerableFactory1(createWorkflow, arg).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a synchronous workflow factory that takes two arguments.
    /// </summary>
    /// <param name="createWorkflow">A factory that takes two arguments and returns a synchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory with the given arguments and yields the events yielded by the resulting synchronous workflow in order.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.StartFromEnumerableFactory2(createWorkflow, arg1, arg2).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a synchronous workflow factory that takes three arguments.
    /// </summary>
    /// <param name="createWorkflow">A factory that takes three arguments and returns a synchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory with the given arguments and yields the events yielded by the resulting synchronous workflow in order.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, IEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.StartFromEnumerableFactory3(createWorkflow, arg1, arg2, arg3).ToWorkflow();
}
