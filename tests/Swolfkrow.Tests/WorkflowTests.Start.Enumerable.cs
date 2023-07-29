using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Start
{
    [Test]
    public async Task FromEventsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        var actualEvents = await Workflow
            .Start(expectedEvents[0], expectedEvents[1], expectedEvents[2])
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEnumerableYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        var actualEvents = await Workflow
            .Start(expectedEvents)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEnumerableFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory() => expectedEvents;

        var actualEvents = await Workflow
            .Start(EventEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEnumerableFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(int arg1) => expectedEvents;

        var actualEvents = await Workflow
            .Start(EventEnumerableFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEnumerableFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(int arg1, string arg2) => expectedEvents;

        var actualEvents = await Workflow
            .Start(EventEnumerableFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEnumerableFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(int arg1, string arg2, long arg3) => expectedEvents;

        var actualEvents = await Workflow
            .Start(EventEnumerableFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
