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
}