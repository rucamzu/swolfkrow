using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class Continue
{
    [Test]
    public async Task WithEventAsyncEnumerableYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventAsyncEnumerableFactoryYieldsAllEvents()
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
    public async Task WithEventAsyncEnumerableFactoryWithOneArgumentYieldsAllEvents()
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
    public async Task WithEventAsyncEnumerableFactoryWithTwoArgumentsYieldsAllEvents()
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
    public async Task WithEventAsyncEnumerableFactoryWithThreeArgumentsYieldsAllEvents()
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
