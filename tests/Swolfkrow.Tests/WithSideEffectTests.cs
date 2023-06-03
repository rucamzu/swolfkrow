using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class WithSideEffectTests
{
    [Test]
    public async Task WorkflowWithSyncSideEffectYieldsWorkflowEvents()
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
    public async Task WorkflowWithSyncSideEffectExecutesSideEffectOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(_ => sideEffectExecutions++)
            .ToListAsync();

        sideEffectExecutions.Should().Be(expectedEvents.Count());
    }

    [Test]
    public async Task WorkflowWithAsyncSideEffectYieldsWorkflowEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(async _ => await Task.Run(() => sideEffectExecutions++))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WorkflowWithAsyncSideEffectExecutesSideEffectOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(async _ => await Task.Run(() => sideEffectExecutions++))
            .ToListAsync();

        sideEffectExecutions.Should().Be(expectedEvents.Count());
    }
}
