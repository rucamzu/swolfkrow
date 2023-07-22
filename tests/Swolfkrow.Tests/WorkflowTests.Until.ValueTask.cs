using Swolfkrow;
using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Until
{
    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyValueTaskPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<bool> Predicate(Some.Event nextEvent)
            => await new ValueTask<bool>(nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyValueTaskPredicateWithOneAdditionalArgument()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<bool> Predicate(Some.Event nextEvent, int arg1)
            => await new ValueTask<bool>(nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyValueTaskPredicateWithTwoAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<bool> Predicate(Some.Event nextEvent, int arg1, string arg2)
            => await new ValueTask<bool>(nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task YieldsFirstEventsThatDoesNotSatisfyValueTaskPredicateWithThreeAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<bool> Predicate(Some.Event nextEvent, int arg1, string arg2, long arg3)
            => await new ValueTask<bool>(nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }
}
