using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class WithStateTests
{
    [Test]
    public async Task StatefulWorkflowsCanBeContinued()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .WithState(
                stateFolder: (currentState, nextEvent) => currentState + 1,
                initialState: 0
            )
            .Then<int, int, Some.Event>(
                createContinuation: eventCount => Some.Workflow.FromEvents(expectedEvents.Skip(eventCount)),
                argSelector: eventCount => eventCount)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public void StatelessWorkflowsCannotBeContinuedWithState()
    {
        var workflow = () => Workflow
            .Start(Some.Workflow.FromEvents(Some.Events(2)))
            // .WithState(
            //     stateFolder: (currentState, nextEvent) => currentState + 1,
            //     initialState: 0
            // )
            .Then<int, int, Some.Event>(
                createContinuation: eventCount => Some.Workflow.FromEvents(Some.Events(eventCount)),
                argSelector: eventCount => eventCount)
            .ToListAsync();

        workflow.Should().Throw<InvalidOperationException>();
    }
}
