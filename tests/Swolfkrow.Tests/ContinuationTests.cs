using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class ContinuationTests
{
    [Test]
    public async Task ContinuationFromExistingWorkflowYieldsAllEventsFromBothWorkflows()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromFactoryYieldsAllEventsFromBothWorkflows()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(() => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromFactoryWithOneArgumentYieldsAllEventsFromBothWorkflows()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int n) => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(n)),
                arg: 2)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromFactoryWithTwoArgumentsYieldsAllEventsFromBothWorkflows()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int n, string s) => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(n)),
                arg1: 2,
                arg2: "some second argument")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromFactoryWithThreeArgumentsYieldsAllEventsFromBothWorkflows()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int n, string s, long l) => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(n)),
                arg1: 2,
                arg2: "some second argument",
                arg3: 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
