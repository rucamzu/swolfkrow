using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Start
{
    [Test]
    public async Task FromValueTaskYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        var actualEvents = await Workflow
            .Start(ValueTask.FromResult(expectedEvent))
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromValueTaskFactoryYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async ValueTask<Some.Event> EventValueTaskFactory()
            => await ValueTask.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventValueTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromValueTaskFactoryWithOneArgumentYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async ValueTask<Some.Event> EventValueTaskFactory(int arg1)
            => await ValueTask.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventValueTaskFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromValueTaskFactoryWithTwoArgumentsYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async ValueTask<Some.Event> EventValueTaskFactory(int arg1, string arg2)
            => await ValueTask.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventValueTaskFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromValueTaskFactoryWithThreeArgumentsYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async ValueTask<Some.Event> EventValueTaskFactory(int arg1, string arg2, long arg3)
            => await ValueTask.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventValueTaskFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }
}
