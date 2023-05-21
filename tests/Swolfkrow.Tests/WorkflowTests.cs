using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class WorkflowTests
{
    [Test]
    public async Task StartReturnsAsynchronousStreamOfWorkflowEvents()
    {
        var eventDescriptions = new[]{ "Some first event", "Some second event" };

        var events = await Workflow
            .Start(TestWorkflow.FromEvents(eventDescriptions.Select(d => new Tests.TestEvent(d))))
            .ToListAsync();

        events.Select(e => e.Description).Should().Equal(eventDescriptions);
    }

    [Test]
    public async Task ExistingWorkflowsCanBeChained()
    {
        var expectedEvents = Enumerable
            .Range(1, 4)
            .Select(i => $"Some event #{i}")
            .Select(description => new TestEvent(description))
            .ToList();

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