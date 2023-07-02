using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Continuation
{
    [Test]
    public async Task FromEventTaskYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(Task.FromResult(expectedEvents!.Last()))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> EventTaskFactory()
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventTaskFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> EventTaskFactory(int arg1)
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventTaskFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventTaskFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> EventTaskFactory(int arg1, string arg2)
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventTaskFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventTaskFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> EventTaskFactory(int arg1, string arg2, long arg3)
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventTaskFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
