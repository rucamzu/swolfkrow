using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class WhenThen
{
    [Test]
    public async Task FromEventTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<Some.Event> EventTaskFactory(Some.Event _)
            => await Task.FromResult(expectedEvents.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .When<Some.Event>().Then(EventTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0], expectedEvents[3],
            expectedEvents[1], expectedEvents[3],
            expectedEvents[2], expectedEvents[3],
        });
    }

    [Test]
    public async Task FromEventTaskFactoryWithPredicateYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<Some.Event> EventTaskFactory(Some.Event _)
            => await Task.FromResult(expectedEvents!.Last());

        bool Predicate(Some.Event nextEvent)
            => nextEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .When<Some.Event>(Predicate).Then(EventTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0],
            expectedEvents[1], expectedEvents[3],
            expectedEvents[2],
        });
    }

    [Test]
    public async Task FromEventTaskFactoryOnSubeventsYieldsAllEvents()
    {
        async Task<Some.Event> EventTaskFactory(Some.SpecificEvent specificEvent)
            => await Task.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));
            
        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"))
            .When<Some.SpecificEvent>().Then(EventTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3")
        });
    }

    [Test]
    public async Task FromEventTaskFactoryOnSubeventsWithPredicateYieldsAllEvents()
    {
        async Task<Some.Event> EventTaskFactory(Some.SpecificEvent specificEvent)
            => await Task.FromResult(new Some.Event($"Continuation from '{specificEvent.Description}'"));

        bool Predicate(Some.SpecificEvent specificEvent)
            => specificEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"))
            .When<Some.SpecificEvent>(Predicate).Then(EventTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3"),
            new Some.SpecificEvent("Some specific event #4"),
        });
    }
}
