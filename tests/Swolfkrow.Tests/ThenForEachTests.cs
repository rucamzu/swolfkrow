using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public class ThenForEachTests
{
    [Test]
    public async Task EventContinuationFromFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(3)))
            .ThenForEach(_ => Workflow.Start(expectedEvents.Skip(3)))
            .ToListAsync();

        actualEvents.Should().Equal(new[]{
            expectedEvents[0], expectedEvents[3], expectedEvents[4],
            expectedEvents[1], expectedEvents[3], expectedEvents[4],
            expectedEvents[2], expectedEvents[3], expectedEvents[4],
        });
    }
}
