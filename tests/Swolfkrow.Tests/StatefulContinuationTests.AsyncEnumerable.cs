using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class StatefulContinuation
{
    [Test]
    public async Task FromEventAsyncEnumerableFactoryAndFolderYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int eventCount)
            => Some.Workflow.FromEvents(expectedEvents!.Skip(eventCount));

        int Folder(int currentState, Some.Event nextEvent)
            => currentState + 1;

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventAsyncEnumerableFactory, Folder, initialState: 0)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryAndTaskFolderYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int eventCount)
            => Some.Workflow.FromEvents(expectedEvents!.Skip(eventCount));

        async Task<int> Folder(int currentState, Some.Event nextEvent)
            => await Task.FromResult(currentState + 1);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventAsyncEnumerableFactory, Folder, initialState: 0)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task FromEventAsyncEnumerableFactoryAndValueTaskFolderYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 5).ToList();

        IAsyncEnumerable<Some.Event> EventAsyncEnumerableFactory(int eventCount)
            => Some.Workflow.FromEvents(expectedEvents!.Skip(eventCount));

        async ValueTask<int> Folder(int currentState, Some.Event nextEvent)
            => await ValueTask.FromResult(currentState + 1);

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents.Take(2)))
            .Then(EventAsyncEnumerableFactory, Folder, initialState: 0)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }
}
