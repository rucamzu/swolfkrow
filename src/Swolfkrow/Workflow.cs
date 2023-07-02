namespace Swolfkrow;

/// <summary>
/// An asynchronous workflow that performs arbitrary computations and yields events.
/// </summary>
/// <typeparam name="TEvent">The type of the events yielded by the asynchronous workflow.</typeparam>
public partial class Workflow<TEvent> : IAsyncEnumerable<TEvent>
{
    /// The wrapped enumerable that implements the asynchronous workflow.
    private readonly IAsyncEnumerable<TEvent> _workflow;

    /// Builds a <see cref="Workflow{TEvent}"/> object by wrapping an existing <see cref="IAsyncEnumerable{T}"/> instance.
    internal Workflow(IAsyncEnumerable<TEvent> workflow)
    {
        _workflow = workflow;
    }

    /// <summary>
    /// Returns an enumerator that progresses the asynchronous workflow in between yielded events.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that may be used to cancel the asynchronous workflow.</param>
    /// <returns>An enumerator that progresses the asynchronous workflow in between yielded events.</returns>
    public IAsyncEnumerator<TEvent> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        => _workflow.GetAsyncEnumerator(cancellationToken);
}