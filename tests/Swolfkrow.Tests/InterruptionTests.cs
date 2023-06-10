using Swolfkrow;
using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Interruption
{
    [Test]
    public async Task WhileYieldsOnlyEventsThatSatisfyPredicate()
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
    public async Task WhileYieldsOnlyEventsThatSatisfyTaskPredicate()
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
    public async Task WhileYieldsOnlyEventsThatSatisfyValueTaskPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<bool> Predicate(Some.Event nextEvent)
            => await new ValueTask<bool>(!nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .While(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(2));
    }

    [Test]
    public async Task UntilYieldsFirstEventsThatDoesNotSatisfyPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        bool Predicate(Some.Event nextEvent)
            => !nextEvent.Description.Contains("3");

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task UntilYieldsFirstEventsThatDoesNotSatisfyTaskPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async Task<bool> Predicate(Some.Event nextEvent)
            => await Task.FromResult(!nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }

    [Test]
    public async Task UntilYieldsFirstEventsThatDoesNotSatisfyValueTaskPredicate()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        async ValueTask<bool> Predicate(Some.Event nextEvent)
            => await new ValueTask<bool>(!nextEvent.Description.Contains("3"));

        var actualEvents = await Workflow
            .Start(Some.Events(howMany: 4))
            .Until(Predicate)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Take(3));
    }
}
