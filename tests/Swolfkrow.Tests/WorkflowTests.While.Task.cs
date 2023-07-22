using Swolfkrow;
using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class While
{
    [Test]
    public async Task YieldsOnlyEventsThatSatisfyTaskPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<bool> Predicate(Some.Event nextEvent)
            => await Task.FromResult(!nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }

    [Test]
    public async Task YieldsOnlyEventsThatSatisfyTaskPredicateWithOneAdditionalArgument()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<bool> Predicate(Some.Event nextEvent, int arg1)
            => await Task.FromResult(!nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }

    [Test]
    public async Task YieldsOnlyEventsThatSatisfyTaskPredicateWithTwoAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<bool> Predicate(Some.Event nextEvent, int arg1, string arg2)
            => await Task.FromResult(!nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }

    [Test]
    public async Task YieldsOnlyEventsThatSatisfyTaskPredicateWithThreeAdditionalArguments()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<bool> Predicate(Some.Event nextEvent, int arg1, string arg2, long arg3)
            => await Task.FromResult(!nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }
}
