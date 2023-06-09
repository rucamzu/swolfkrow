using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class SideEffect
{
    [Test]
    public async Task FromActionExecutesOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var effectedEvents = new List<Some.Event>();

        void SideEffect(Some.Event nextEvent)
            => effectedEvents!.Add(nextEvent);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(SideEffect)
            .ToListAsync();

        effectedEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromActionPreservesEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var effectedEvents = new List<Some.Event>();

        void SideEffect(Some.Event nextEvent)
            => effectedEvents!.Add(nextEvent);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(SideEffect)
            .ToListAsync();

        expectedEvents.Should().Equal(expectedEvents);
    }
}
