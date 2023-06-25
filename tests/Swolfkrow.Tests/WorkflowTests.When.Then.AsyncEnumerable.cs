using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class WhenThen
{
    [Test]
    public async Task FromEventAsyncEnumerableFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(Some.Event _)
            => Some.Workflow.FromEvents(expectedEvents.Skip(3));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .When<Some.Event>().Then(EventAsyncEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0], expectedEvents[3], expectedEvents[4],
            expectedEvents[1], expectedEvents[3], expectedEvents[4],
            expectedEvents[2], expectedEvents[3], expectedEvents[4],
        });
    }

    [Test]
    public async Task FromEventAsyncEnumerableWithPredicateFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(Some.Event _)
            => Some.Workflow.FromEvents(expectedEvents.Skip(3));

        bool Predicate(Some.Event nextEvent)
            => nextEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .When<Some.Event>(Predicate).Then(EventAsyncEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            expectedEvents[0],
            expectedEvents[1], expectedEvents[3], expectedEvents[4],
            expectedEvents[2],
        });
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryOnSubeventsYieldsAllEvents()
    {
        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(Some.SpecificEvent specificEvent)
            => Some.Workflow.FromEvents(new Some.Event($"Continuation from '{specificEvent.Description}'"));

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"))
            .When<Some.SpecificEvent>().Then(EventAsyncEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3")
        });
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryOnSubeventsWithPredicateYieldsAllEvents()
    {
        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(Some.SpecificEvent specificEvent)
            => Some.Workflow.FromEvents(new Some.Event($"Continuation from '{specificEvent.Description}'"));

        bool Predicate(Some.SpecificEvent specificEvent)
            => specificEvent.Description.Contains("2");

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.SpecificEvent("Some specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"))
            .When<Some.SpecificEvent>(Predicate).Then(EventAsyncEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
            new Some.Event("Some event #1"),
            new Some.SpecificEvent("Some specific event #2"), new Some.Event($"Continuation from 'Some specific event #2'"),
            new Some.Event("Some event #3"),
            new Some.SpecificEvent("Some specific event #4"),
        });
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryOnTwoSubeventsYieldsAllEvents()
    {
        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(Some.SpecificEvent _, Some.OtherSpecificEvent __)
            => Some.Workflow.FromEvents(new Some.Event($"from continuation"));

        var actualEvents = await Workflow
            .Start(
                new Some.Event("Some event #1"),
                new Some.OtherSpecificEvent("Some other specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"),
                new Some.Event("Some event #5"),
                new Some.Event("Some event #6"))
            .When<Some.SpecificEvent, Some.OtherSpecificEvent>().Then(EventAsyncEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[] {
                new Some.Event("Some event #1"),
                new Some.OtherSpecificEvent("Some other specific event #2"),
                new Some.Event("Some event #3"),
                new Some.SpecificEvent("Some specific event #4"), new Some.Event("from continuation"),
                new Some.Event("Some event #5"),
                new Some.Event("Some event #6")
            });
    }
}
