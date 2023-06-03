using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class ContinuationTests
{
    [Test]
    public async ValueTask ContinuationFromValueTaskYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async ValueTask<Some.Event> CreateContinuation()
            => await ValueTask.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation())
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async ValueTask ContinuationFromValueTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async ValueTask<Some.Event> CreateContinuation()
            => await ValueTask.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async ValueTask ContinuationFromValueTaskFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async ValueTask<Some.Event> CreateContinuation(int _)
            => await ValueTask.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation, 7)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async ValueTask ContinuationFromValueTaskFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async ValueTask<Some.Event> CreateContinuation(int _, string __)
            => await ValueTask.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation, 7, "hello")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async ValueTask ContinuationFromValueTaskFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async ValueTask<Some.Event> CreateContinuation(int _, string __, long ___)
            => await ValueTask.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation, 7, "hello", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
