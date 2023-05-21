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
}
