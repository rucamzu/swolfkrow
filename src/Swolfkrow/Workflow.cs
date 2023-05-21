namespace Swolfkrow;

/// <summary>
/// Factory methods and extension methods to compose asynchronous workflows based on <see cref="IAsyncEnumerable{T}"/>.
/// </summary>
public static class Workflow
{
    /// <summary>
    /// Starts an existing asynchronous workflow.
    /// </summary>
    /// <param name="workflow">An asynchronous workflow.</param>
    /// <typeparam name="TEvent">The (base) type of the events returned by the asynchronous <paramref name="workflow"/>.</typeparam>
    /// <returns>The given <paramref name="workflow"/>.</returns>
    /// <remarks>
    /// This function does nothing apart from returning the existing asynchronous workflow. Its purpose is to serve as entry point for the DSL. 
    /// </remarks>
    public static IAsyncEnumerable<TEvent> Start<TEvent>(IAsyncEnumerable<TEvent> workflow)
        => workflow;
}
