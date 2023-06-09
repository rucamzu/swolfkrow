using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class SideEffect
{
    [Test]
    public async Task FromTaskExecutesOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var effectedEvents = new List<Some.Event>();

        async Task SideEffect(Some.Event nextEvent)
            => await Task.Run(() => effectedEvents!.Add(nextEvent));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(SideEffect)
            .ToListAsync();

        effectedEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromTaskPreservesEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var effectedEvents = new List<Some.Event>();

        async Task SideEffect(Some.Event nextEvent)
            => await Task.Run(() => effectedEvents!.Add(nextEvent));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .WithSideEffect(SideEffect)
            .ToListAsync();

        expectedEvents.Should().Equal(expectedEvents);
    }
}
