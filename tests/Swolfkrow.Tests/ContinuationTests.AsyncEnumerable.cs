using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class Continuation
{
    [Test]
    public async Task FromEventAsyncEnumerableYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory()
            => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventAsyncEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int arg1)
            => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventAsyncEnumerableFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int arg1, string arg2)
            => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventAsyncEnumerableFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int arg1, string arg2, long arg3)
            => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2));

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventAsyncEnumerableFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
