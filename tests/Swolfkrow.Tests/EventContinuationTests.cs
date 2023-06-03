using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class EventContinuationTests
{
    [Test]
    public async Task EventContinuationFromFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .ThenForEach(_ => Workflow.Start(expectedEvents.Skip(3)))
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0], expectedEvents[3], expectedEvents[4],
            expectedEvents[1], expectedEvents[3], expectedEvents[4],
            expectedEvents[2], expectedEvents[3], expectedEvents[4],
        });
    }

    [Test]
    public async Task ConditionalEventContinuationFromFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .ThenForEach(
                _ => Workflow.Start(expectedEvents.Skip(3)),
                nextEvent => nextEvent.Description.Contains("2"))
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0],
            expectedEvents[1], expectedEvents[3], expectedEvents[4],
            expectedEvents[2],
        });
    }

    [Test]
    public async Task SubEventContinuationFromFactoryYieldsAllEvents()
    {
        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"))
            .ThenForEach((Some.SpecificEvent specificEvent) =>
                 Workflow.Start<Some.Event>(new Some.Event($"Continuation from '{specificEvent.Description}'")))
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"),
            new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3")
        });
    }

    [Test]
    public async Task ConditionalSubEventContinuationFromFactoryYieldsAllEvents()
    {
        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"))
            .ThenForEach(
                (Some.SpecificEvent specificEvent) => Workflow.Start<Some.Event>(new Some.Event($"Continuation from '{specificEvent.Description}'")),
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
