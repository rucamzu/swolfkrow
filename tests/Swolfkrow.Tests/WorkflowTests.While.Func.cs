using Swolfkrow;
using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class While
{
    [Test]
    public async Task YieldsOnlyEventsThatSatisfyPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent)
            => !nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }

    [Test]
    public async Task YieldsOnlyEventsThatSatisfyPredicateWithOneAdditionalArgument()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent, int arg1)
            => !nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }

    [Test]
    public async Task YieldsOnlyEventsThatSatisfyPredicateWithTwoAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent, int arg1, string arg2)
            => !nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }

    [Test]
    public async Task YieldsOnlyEventsThatSatisfyPredicateWithThreeAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent, int arg1, string arg2, long arg3)
            => !nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }
}
