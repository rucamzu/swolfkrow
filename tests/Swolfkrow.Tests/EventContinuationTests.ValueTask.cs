using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class EventContinuationTests
{
    [Test]
    public async ValueTask EventContinuationFromValueTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<Some.Event> CreateContinuation(Some.Event _)
            => await ValueTask.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .ThenForEach(CreateContinuation)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0], expectedEvents[3],
            expectedEvents[1], expectedEvents[3],
            expectedEvents[2], expectedEvents[3],
        });
    }

    [Test]
    public async ValueTask ConditionalEventContinuationFromValueTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<Some.Event> CreateContinuation(Some.Event _)
            => await ValueTask.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .ThenForEach(CreateContinuation,
                nextEvent => nextEvent.Description.Contains("2"))
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0],
            expectedEvents[1], expectedEvents[3],
            expectedEvents[2],
        });
    }

    [Test]
    public async ValueTask SubEventContinuationFromValueTaskFactoryYieldsAllEvents()
    {
        async ValueTask<Some.Event> CreateContinuation(Some.SpecificEvent specificEvent)
            => await ValueTask.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));
            
        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"))
            .ThenForEach<Some.Event, Some.SpecificEvent>(CreateContinuation)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"),
            new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3")
        });
    }

    [Test]
    public async ValueTask ConditionalSubEventContinuationFromValueTaskFactoryYieldsAllEvents()
    {
        async ValueTask<Some.Event> CreateContinuation(Some.SpecificEvent specificEvent)
            => await ValueTask.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"))
            .ThenForEach(CreateContinuation,
                (Some.SpecificEvent specificEvent) => specificEvent.Description.Contains("2"))
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3"),
            new Some.SpecificEvent("Some specific event #4"),
        });
    }
}
