using Swolfkrow;
using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Until
{
    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent)
            => nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyPredicateWithOneAdditionalArgument()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent, int arg1)
            => nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyPredicateWithTwoAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent, int arg1, string arg2)
            => nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyPredicateWithThreeAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent, int arg1, string arg2, long arg3)
            => nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }
}
