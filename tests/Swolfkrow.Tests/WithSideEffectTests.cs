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

        void IncrementExecutions(Some.Event _) => sideEffectExecutions++;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(IncrementExecutions)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WorkflowWithSyncSideEffectExecutesSideEffectOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        void IncrementExecutions(Some.Event _) => sideEffectExecutions++;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(IncrementExecutions)
            .ToListAsync();

        sideEffectExecutions.Should().Be(expectedEvents.Count());
    }

    [Test]
    public async Task WorkflowWithTaskSideEffectYieldsWorkflowEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        async Task IncrementExecutions(Some.Event _) => await Task.Run(() => sideEffectExecutions++);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(IncrementExecutions)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WorkflowWithTaskSideEffectExecutesSideEffectOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var sideEffectExecutions = 0;

        async Task IncrementExecutions(Some.Event _) => await Task.Run(() => sideEffectExecutions++);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(IncrementExecutions)
            .ToListAsync();

        sideEffectExecutions.Should().Be(expectedEvents.Count());
    }
}
