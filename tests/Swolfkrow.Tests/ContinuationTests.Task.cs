using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

public partial class ContinuationTests
{
    [Test]
    public async Task ContinuationFromTaskYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> CreateContinuation()
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation())
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromTaskFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> CreateContinuation()
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromTaskFactoryWithOneArgumentYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> CreateContinuation(int _)
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation, 7)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromTaskFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> CreateContinuation(int _, string __)
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation, 7, "hello")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task ContinuationFromTaskFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 3).ToList();

        async Task<Some.Event> CreateContinuation(int _, string __, long ___)
            => await Task.FromResult(expectedEvents!.Last());

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(CreateContinuation, 7, "hello", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
