using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class WorkflowTests
{
    [Test]
    public async Task StartReturnsAsynchronousStreamOfWorkflowEvents()
    {
        var expectedEvents = Some.Events(howMany: 2).ToList();

        var actualEvents = await Workflow
            .Start(TestWorkflow.FromEvents(expectedEvents))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ExistingWorkflowsCanBeChained()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(TestWorkflow.FromEvents(expectedEvents.Take(2)))
            .Then(TestWorkflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}

public record TestEvent(string Description);

public static class TestWorkflow
{
    public static IAsyncEnumerable<TestEvent> FromEvents(params TestEvent[] events)
        => FromEvents((IEnumerable<TestEvent>) events);

    public static IAsyncEnumerable<TestEvent> FromEvents(IEnumerable<TestEvent> events)
        => events.ToAsyncEnumerable();
}

public static class Some
{
    public static IEnumerable<TestEvent> Events(int howMany)
        => Enumerable
            .Range(1, howMany)
            .Select(i => $"Some event #{i}")
            .Select(description => new TestEvent(description));
}