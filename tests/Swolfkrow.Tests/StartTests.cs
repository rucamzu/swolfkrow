using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class StartTests
{
    [Test]
    public async Task StartExistingWorkflowYieldsWorkflowEvents()
    {
        var expectedEvents = Some.Events(howMany: 2).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task StartWorkflowFromFactoryFunctionYieldsWorkflowEvents()
    {
        var expectedEvents = Some.Events(howMany: 2).ToList();

        var actualEvents = await Workflow
            .Start(() => Some.Workflow.FromEvents(expectedEvents))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task StartWorkflowFromFactoryFunctionWithArgumentYieldsWorkflowEvents()
    {
        var actualEvents = await Workflow
            .Start(
                createWorkflow: (int n) => Some.Workflow.FromEvents(Some.Events(howMany: n)),
                arg: 3)
            .ToListAsync();

        actualEvents.Should().Equal(Some.Events(howMany: 3));
    }
}
