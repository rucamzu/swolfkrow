using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class Continue
{
    [Test]
    public async Task WithEventParamsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(expectedEvents[2], expectedEvents[3])
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventEnumerableYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(expectedEvents.Skip(2).Take(2))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventEnumerableFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory()
            => expectedEvents.Skip(2).Take(2);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventEnumerableFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(int arg1)
            => expectedEvents.Skip(2).Take(2);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventEnumerableFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventEnumerableFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(int arg1, string arg2)
            => expectedEvents.Skip(2).Take(2);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventEnumerableFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventEnumerableFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IEnumerable<Some.Event> EventEnumerableFactory(int arg1, string arg2, long arg3)
            => expectedEvents.Skip(2).Take(2);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventEnumerableFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
