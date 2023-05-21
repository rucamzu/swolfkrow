using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class ThenTests
{
    [Test]
    public async Task ChainedExistingWorkflowsYieldsAllEventsFromBothWorkflows()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ChainedWorkflowFactoriesYieldAllEventsFromBothWorkflows()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(() => Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(() => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }


    [Test]
    public async Task ChainedWorkflowFactoryWithArgumentYieldsAllEventsFromBothWorkflows()
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
}
