using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Start
{
    [Test]
    public async Task StartExistingWorkflowYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 2).ToList();

        var actualEvents = await Workflow
            .Start(Some.Workflow.FromEvents(expectedEvents))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task StartWorkflowFromFactoryYieldsAllEvents()
    {
        var expectedEvents = Some.Events(howMany: 2).ToList();

        var actualEvents = await Workflow
            .Start(() => Some.Workflow.FromEvents(expectedEvents))
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents);
    }

    [Test]
    public async Task StartWorkflowFromFactoryWithOneArgumentYieldsAllEvents()
    {
        var actualEvents = await Workflow
            .Start(
                createWorkflow: (int n) => Some.Workflow.FromEvents(Some.Events(howMany: n)),
                arg: 3)
            .ToListAsync();

        actualEvents.Should().Equal(Some.Events(howMany: 3));
    }

    [Test]
    public async Task StartWorkflowFromFactoryWithTwoArgumentsYieldsAllEvents()
    {
        var actualEvents = await Workflow
            .Start(
                createWorkflow: (int n, string s) => Some.Workflow.FromEvents(Some.Events(howMany: n)),
                arg1: 3,
                arg2: "some second argument")
            .ToListAsync();

        actualEvents.Should().Equal(Some.Events(howMany: 3));
    }

    [Test]
    public async Task StartWorkflowFromFactoryWithThreeArgumentsYieldsAllEvents()
    {
        var actualEvents = await Workflow
            .Start(
                createWorkflow: (int n, string s, long l) => Some.Workflow.FromEvents(Some.Events(howMany: n)),
                arg1: 3,
                arg2: "some second argument",
                arg3: 42L)
            .ToListAsync();

        actualEvents.Should().Equal(Some.Events(howMany: 3));
    }

    public async Task StartWorkflowFromTaskYieldsTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 1);

        async Task<Some.Event> CreateTask() => await Task.FromResult(expectedEvents!.Single());

        var actualEvents = await Workflow
            .Start(CreateTask())
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents).And.HaveCount(1);
    }

    public async Task StartWorkflowFromTaskFactoryYieldsTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 1);

        async Task<Some.Event> CreateTask() => await Task.FromResult(expectedEvents!.Single());

        var actualEvents = await Workflow
            .Start(CreateTask)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents).And.HaveCount(1);
    }

    public async Task StartWorkflowFromTaskFactoryWithOneArgumentYieldsTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 5);

        async Task<Some.Event> CreateTask(int n) => await Task.FromResult(expectedEvents!.Skip(n-1).Take(1).Single());

        var actualEvents = await Workflow
            .Start(CreateTask, 3)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Skip(2).Take(1)).And.HaveCount(1);
    }

    public async Task StartWorkflowFromTaskFactoryWithTwoArgumentsYieldsTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 5);

        async Task<Some.Event> CreateTask(int n, string _) => await Task.FromResult(expectedEvents!.Skip(n-1).Take(1).Single());

        var actualEvents = await Workflow
            .Start(CreateTask, 3, "hello")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Skip(2).Take(1)).And.HaveCount(1);
    }

    public async Task StartWorkflowFromTaskFactoryWithThreeArgumentsYieldsTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 5);

        async Task<Some.Event> CreateTask(int n, string _, long __) => await Task.FromResult(expectedEvents!.Skip(n-1).Take(1).Single());

        var actualEvents = await Workflow
            .Start(CreateTask, 3, "hello", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Skip(2).Take(1)).And.HaveCount(1);
    }

    public async Task StartWorkflowFromValueTaskYieldsValueTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 1);

        async ValueTask<Some.Event> CreateValueTask() => await ValueTask.FromResult(expectedEvents!.Single());

        var actualEvents = await Workflow
            .Start(CreateValueTask())
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents).And.HaveCount(1);
    }

    public async Task StartWorkflowFromValueTaskFactoryYieldsValueTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 1);

        async ValueTask<Some.Event> CreateValueTask() => await ValueTask.FromResult(expectedEvents!.Single());

        var actualEvents = await Workflow
            .Start(CreateValueTask)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents).And.HaveCount(1);
    }

    public async Task StartWorkflowFromValueTaskFactoryWithOneArgumentYieldsValueTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 5);

        async ValueTask<Some.Event> CreateTask(int n) => await ValueTask.FromResult(expectedEvents!.Skip(n-1).Take(1).Single());

        var actualEvents = await Workflow
            .Start(CreateTask, 3)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Skip(2).Take(1)).And.HaveCount(1);
    }

    public async Task StartWorkflowFromValueTaskFactoryWithTwoArgumentsYieldsValueTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 5);

        async ValueTask<Some.Event> CreateTask(int n, string _) => await ValueTask.FromResult(expectedEvents!.Skip(n-1).Take(1).Single());

        var actualEvents = await Workflow
            .Start(CreateTask, 3, "hello")
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Skip(2).Take(1)).And.HaveCount(1);
    }

    public async Task StartWorkflowFromValueTaskFactoryWithThreeArgumentsYieldsValueTaskResult()
    {
        var expectedEvents = Some.Events(howMany: 5);

        async ValueTask<Some.Event> CreateTask(int n, string _, long __) => await ValueTask.FromResult(expectedEvents!.Skip(n-1).Take(1).Single());

        var actualEvents = await Workflow
            .Start(CreateTask, 3, "hello", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(expectedEvents.Skip(2).Take(1)).And.HaveCount(1);
    }
}
