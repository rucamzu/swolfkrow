using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Start
{
    [Test]
    public async Task FromAsyncEnumerableYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromAsyncEnumerableFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory()
            => Some.Workflow.FromEvents(expectedEvents);

        var actualEvents = await Workflow
            .Start(EventAsyncEnumerableFactory)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromAsyncEnumerableFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int arg1)
            => Some.Workflow.FromEvents(expectedEvents);

        var actualEvents = await Workflow
            .Start(EventAsyncEnumerableFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromAsyncEnumerableFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int arg1, string arg2)
            => Some.Workflow.FromEvents(expectedEvents);

        var actualEvents = await Workflow
            .Start(EventAsyncEnumerableFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromAsyncEnumerableFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int arg1, string arg2, long arg3)
            => Some.Workflow.FromEvents(expectedEvents);

        var actualEvents = await Workflow
            .Start(EventAsyncEnumerableFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
