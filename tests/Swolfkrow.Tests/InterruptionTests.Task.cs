using Swolfkrow;
using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Interruption
{
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
}
