using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Start
{
    [Test]
    public async Task FromTaskYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        var actualEvents = await Workflow
            .Start(Task.FromResult(expectedEvent))
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromTaskFactoryYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async Task<Some.Event> EventTaskFactory()
            => await Task.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventTaskFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromTaskFactoryWithOneArgumentYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async Task<Some.Event> EventTaskFactory(int arg1)
            => await Task.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventTaskFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromTaskFactoryWithTwoArgumentsYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async Task<Some.Event> EventTaskFactory(int arg1, string arg2)
            => await Task.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventTaskFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromTaskFactoryWithThreeArgumentsYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        async Task<Some.Event> EventTaskFactory(int arg1, string arg2, long arg3)
            => await Task.FromResult(expectedEvent);

        var actualEvents = await Workflow
            .Start(EventTaskFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }
}
