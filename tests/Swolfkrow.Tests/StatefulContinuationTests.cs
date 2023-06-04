using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class StatefulContinuationTests
{
    [Test]
    public async Task StatefulContinuationYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int eventCount) => Some.Workflow.FromEvents(expectedEvents.Skip(eventCount)),
                computeNextState: (currentState, nextEvent) => currentState + 1,
                initialState: 0)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task StatefulContinuationWithTaskFolderYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        async Task<int> IncrementState(int currentState, Some.Event _)
            => await Task.FromResult(currentState + 1);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int eventCount) => Some.Workflow.FromEvents(expectedEvents.Skip(eventCount)),
                computeNextState: IncrementState,
                initialState: 0)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task StatefulContinuationWithValueTaskFolderYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        async ValueTask<int> IncrementState(int currentState, Some.Event _)
            => await ValueTask.FromResult(currentState + 1);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int eventCount) => Some.Workflow.FromEvents(expectedEvents.Skip(eventCount)),
                computeNextState: IncrementState,
                initialState: 0)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
