using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class WithSideEffectTests
{
    [Test]
    public async Task WorkflowWithSideEffectYieldsWorkflowEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(_ => sideEffectExecutions++)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WorkflowWithSideEffectExecutesSideEffectOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(_ => sideEffectExecutions++)
            .ToListAsync();

        sideEffectExecutions.Should().Be(expectedEvents.Count());
    }
}
