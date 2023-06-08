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

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(() => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(2)))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventAsyncEnumerableFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int n) => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(n)),
                arg: 2)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventAsyncEnumerableFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int n, string s) => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(n)),
                arg1: 2,
                arg2: "some second argument")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task WithEventAsyncEnumerableFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 4).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(
                createContinuation: (int n, string s, long l) => Some.Workflow.FromEvents(expectedEvents.Skip(2).Take(n)),
                arg1: 2,
                arg2: "some second argument",
                arg3: 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
