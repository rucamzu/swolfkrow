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
    public async Task UntilYieldsFirstEventsThatDoesNotSatisfyPredicate()
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
}
