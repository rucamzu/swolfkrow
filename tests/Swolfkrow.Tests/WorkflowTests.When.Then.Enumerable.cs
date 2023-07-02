using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class WhenThen
{
    [Test]
    public async Task FromEventEnumerableFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(Some.Event _)
            => expectedEvents.Skip(3);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .When<Some.Event>().Then(EventEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0], expectedEvents[3], expectedEvents[4],
            expectedEvents[1], expectedEvents[3], expectedEvents[4],
            expectedEvents[2], expectedEvents[3], expectedEvents[4],
        });
    }

    [Test]
    public async Task FromEventEnumerableWithPredicateFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(Some.Event _)
            => expectedEvents.Skip(3);

        bool Predicate(Some.Event nextEvent)
            => nextEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .When<Some.Event>(Predicate).Then(EventEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0],
            expectedEvents[1], expectedEvents[3], expectedEvents[4],
            expectedEvents[2],
        });
    }

    [Test]
    public async Task FromEventEnumerableFactoryOnSubeventsYieldsAllEvents()
    {
        IEnumerable<Some.Event> EventEnumerableFactory(Some.SpecificEvent specificEvent)
            => new[] { new Some.Event($"Continuation from '{specificEvent.Description}'") };

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"))
            .When<Some.SpecificEvent>().Then(EventEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3")
        });
    }

    [Test]
    public async Task FromEventEnumerableFactoryOnSubeventsWithPredicateYieldsAllEvents()
    {
        IEnumerable<Some.Event> EventEnumerableFactory(Some.SpecificEvent specificEvent)
            => new[] { new Some.Event($"Continuation from '{specificEvent.Description}'") };

        bool Predicate(Some.SpecificEvent specificEvent)
            => specificEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"))
            .When<Some.SpecificEvent>(Predicate).Then(EventEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3"),
            new Some.SpecificEvent("Some specific event #4"),
        });
    }
}
