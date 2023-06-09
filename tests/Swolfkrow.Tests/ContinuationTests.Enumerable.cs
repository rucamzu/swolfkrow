using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class Continuation
{
    [Test]
    public async Task FromEventParamsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(expectedEvents[2], expectedEvents[3])
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventEnumerableYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(expectedEvents.Skip(2).Take(2))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventEnumerableFactoryYieldsAllEvents()
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
    public async Task FromEventEnumerableFactoryWithOneArgumentYieldsAllEvents()
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
    public async Task FromEventEnumerableFactoryWithTwoArgumentsYieldsAllEvents()
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
    public async Task FromEventEnumerableFactoryWithThreeArgumentsYieldsAllEvents()
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
