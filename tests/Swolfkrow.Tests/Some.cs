using FluentAssertions;
using NUnit.Framework;

namespace Swolfkrow.Tests;

/// <summary>
/// Test data and types/functions to create test data.
/// </summary>
internal static class Some
{
    public record Event(string Description);

    public record SpecificEvent(string Description) : Some.Event(Description);

    public static class Workflow
    {
        public static IAsyncEnumerable<Event> FromEvents(params Event[] events)
            => FromEvents((IEnumerable<Event>) events);

        public static IAsyncEnumerable<Event> FromEvents(IEnumerable<Event> events)
            => events.ToAsyncEnumerable();
    }

    public static IEnumerable<Event> Events(int howMany)
        => Enumerable
            .Range(1, howMany)
            .Select(i => $"Some event #{i}")
            .Select(description => new Event(description));
}