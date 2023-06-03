using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class EventContinuationTests
{
    [Test]
    public async Task EventContinuationFromTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<Some.Event> CreateContinuation(Some.Event _)
            => await Task.FromResult(expectedEvents!.Last());

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
    public async Task ConditionalEventContinuationFromTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<Some.Event> CreateContinuation(Some.Event _)
            => await Task.FromResult(expectedEvents!.Last());

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
    public async Task SubEventContinuationFromTaskFactoryYieldsAllEvents()
    {
        async Task<Some.Event> CreateContinuation(Some.SpecificEvent specificEvent)
            => await Task.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));
            
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
    public async Task ConditionalSubEventContinuationFromTaskFactoryYieldsAllEvents()
    {
        async Task<Some.Event> CreateContinuation(Some.SpecificEvent specificEvent)
            => await Task.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));

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
