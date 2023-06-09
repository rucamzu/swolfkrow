using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

[TestFixture]
public partial class Start
{
    [Test]
    public async Task FromEventFactoryYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        Some.Event EventFactory() => expectedEvent;

        var actualEvents = await Workflow
            .Start(EventFactory)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromEventFactoryWithOneArgumentYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        Some.Event EventFactory(int arg1) => expectedEvent;

        var actualEvents = await Workflow
            .Start(EventFactory, 42)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromEventFactoryWithTwoArgumentYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        Some.Event EventFactory(int arg1, string arg2) => expectedEvent;

        var actualEvents = await Workflow
            .Start(EventFactory, 42, "42")
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }

    [Test]
    public async Task FromEventFactoryWithThreeArgumentYieldsResultingEvent()
    {
        var expectedEvent = Some.Events(howMany: 1).Single();

        Some.Event EventFactory(int arg1, string arg2, long arg3) => expectedEvent;

        var actualEvents = await Workflow
            .Start(EventFactory, 42, "42", 42L)
            .ToListAsync();

        actualEvents.Should().Equal(new[]{ expectedEvent });
    }
}
