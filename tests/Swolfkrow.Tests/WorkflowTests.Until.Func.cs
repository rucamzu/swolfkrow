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
}
