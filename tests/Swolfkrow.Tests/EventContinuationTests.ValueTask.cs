using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class EventContinuation
{
    [Test]
    public async Task FromValueTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<Some.Event> EventValueTaskFactory(Some.Event _)
            => await ValueTask.FromResult(expectedEvents.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .ThenForEach(EventValueTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0], expectedEvents[3],
            expectedEvents[1], expectedEvents[3],
            expectedEvents[2], expectedEvents[3],
        });
    }

    [Test]
    public async Task FromValueTaskFactoryWithPredicateYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<Some.Event> EventValueTaskFactory(Some.Event _)
            => await ValueTask.FromResult(expectedEvents!.Last());

        bool Predicate(Some.Event nextEvent)
            => nextEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .ThenForEach(EventValueTaskFactory, Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0],
            expectedEvents[1], expectedEvents[3],
            expectedEvents[2],
        });
    }

    [Test]
    public async Task FromValueTaskFactoryOnSubeventsYieldsAllEvents()
    {
        async ValueTask<Some.Event> EventValueTaskFactory(Some.SpecificEvent specificEvent)
            => await ValueTask.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));
            
        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"))
            .ThenForEach<Some.Event, Some.SpecificEvent>(EventValueTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3")
        });
    }

    [Test]
    public async Task FromValueTaskFactoryOnSubeventsWithPredicateYieldsAllEvents()
    {
        async ValueTask<Some.Event> EventValueTaskFactory(Some.SpecificEvent specificEvent)
            => await ValueTask.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));

        bool Predicate(Some.SpecificEvent specificEvent)
            => specificEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"))
            .ThenForEach<Some.Event, Some.SpecificEvent>(EventValueTaskFactory, Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3"),
            new Some.SpecificEvent("Some specific event #4"),
        });
    }
}
