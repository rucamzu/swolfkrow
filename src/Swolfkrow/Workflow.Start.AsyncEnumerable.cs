using Swolfkrow.Impl;

namespace Swolfkrow;

/// <summary>
/// Factory methods to create asynchronous workflows.
/// </summary>
public static partial class Workflow
{
    /// <summary>
    /// Starts an asynchronous <paramref name="workflow"/> from an asynchronous workflow.
    /// </summary>
    /// <param name="workflow">An existing asynchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that yields the events of the given <paramref name="workflow"/>.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL. It is an identity function, functionally equivalent to directly accessing the given <paramref name="workflow"/>.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(IAsyncEnumerable<TEvent> workflow)
        => WorkflowImpl.StartFromAsyncEnumerable(workflow).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a factory.
    /// </summary>
    /// <param name="createWorkflow">A factory that returns an asynchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory and yields the events of the resulting asynchronous workflow.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL. It is functionally equivalent to directly calling the given <paramref name="createWorkflow"/> factory.
    /// </remarks>
    public static Workflow<TEvent> Start<TEvent>(Func<IAsyncEnumerable<TEvent>> createWorkflow)
        => WorkflowImpl.StartFromAsyncEnumerableFactory(createWorkflow).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a factory that takes one argument.
    /// </summary>
    /// <param name="createWorkflow">A factory that takes one argument and returns an asynchronous workflow.</param>
    /// <param name="arg">The argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <typeparam name="TArg">The type of the argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory with the given <paramref name="arg"/>ument and yields the events of the resulting asynchronous workflow.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL. It is functionally equivalent to directly calling the given <paramref name="createWorkflow"/> factory with the given <paramref name="arg"/>ument.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg, TEvent>(
        Func<TArg, IAsyncEnumerable<TEvent>> createWorkflow, TArg arg)
        => WorkflowImpl.StartFromAsyncEnumerableFactory1(createWorkflow, arg).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a factory that takes two arguments.
    /// </summary>
    /// <param name="createWorkflow">A factory that takes two arguments and returns an asynchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory with the given arguments and yields the events of the resulting asynchronous workflow.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL. It is functionally equivalent to directly calling the given <paramref name="createWorkflow"/> factory with the given arguments.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TEvent>(
        Func<TArg1, TArg2, IAsyncEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2)
        => WorkflowImpl.StartFromAsyncEnumerableFactory2(createWorkflow, arg1, arg2).ToWorkflow();

    /// <summary>
    /// Starts an asynchronous <see cref="Workflow{TEvent}"/> from a factory that takes three arguments.
    /// </summary>
    /// <param name="createWorkflow">A factory that takes three arguments and returns an asynchronous workflow.</param>
    /// <param name="arg1">The first argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <param name="arg2">The second argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <param name="arg3">The third argument passed to the given <paramref name="createWorkflow"/> factory.</param>
    /// <typeparam name="TArg1">The type of the first argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TArg2">The type of the second argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TArg3">The type of the third argument passed to the given <paramref name="createWorkflow"/> factory.</typeparam>
    /// <typeparam name="TEvent">The (base) type of the events yielded by the asynchronous workflow.</typeparam>
    /// <returns>An asynchronous <see cref="Workflow{TEvent}"/> that calls the given <paramref name="createWorkflow"/> factory with the given arguments and yields the events of the resulting asynchronous workflow.</returns>
    /// <remarks>
    /// This function serves as entry point to the DSL. It is functionally equivalent to directly calling the given <paramref name="createWorkflow"/> factory with the given arguments.
    /// </remarks>
    public static Workflow<TEvent> Start<TArg1, TArg2, TArg3, TEvent>(
        Func<TArg1, TArg2, TArg3, IAsyncEnumerable<TEvent>> createWorkflow, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => WorkflowImpl.StartFromAsyncEnumerableFactory3(createWorkflow, arg1, arg2, arg3).ToWorkflow();
}
