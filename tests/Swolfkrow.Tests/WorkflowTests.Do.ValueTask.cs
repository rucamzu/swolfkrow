using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class SideEffect
{
    [Test]
    public async Task FromValueTaskExecutesOncePerEvent()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var effectedEvents = new List<Some.Event>();

        async ValueTask SideEffect(Some.Event nextEvent)
            => effectedEvents!.Add(await new ValueTask<Some.Event>(nextEvent));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .Do(SideEffect)
            .ToListAsync();

        effectedEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromValueTaskPreservesEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();
        var effectedEvents = new List<Some.Event>();

        async ValueTask SideEffect(Some.Event nextEvent)
            => effectedEvents!.Add(await new ValueTask<Some.Event>(nextEvent));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .Do(SideEffect)
            .ToListAsync();

        expectedEvents.Should().Equal(expectedEvents);
    }
}
