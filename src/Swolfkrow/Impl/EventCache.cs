namespace Swolfkrow.Impl;

internal class EventCache1<TEvent>
{
    private CachedEvent<TEvent> _cachedEvent = CachedEvent.Empty<TEvent>();

    public bool Cache(TEvent nextEvent)
    {
        _cachedEvent = CachedEvent.Cached(nextEvent);
        return true;
    }

    public bool IsCached => _cachedEvent.IsCached;

    public TEvent? Event => _cachedEvent.Event;
}

internal class EventCache1<TEvent, TCachedEvent>
    where TCachedEvent : TEvent
{
    private CachedEvent<TCachedEvent> _cachedEvent = CachedEvent.Empty<TCachedEvent>();

    public bool Cache(TEvent nextEvent)
    {
        switch (nextEvent)
        {
            case TCachedEvent cachedEvent:
                _cachedEvent = CachedEvent.Cached(cachedEvent);
                return true;

            default:
                return false;
        }
    }

    public bool IsCached => _cachedEvent.IsCached;

    public TCachedEvent? Event => _cachedEvent.Event;
}

internal class EventCache2<TEvent, TCachedEvent>
    where TCachedEvent : TEvent
{
    private CachedEvent<TCachedEvent> _cachedEvent1 = CachedEvent.Empty<TCachedEvent>();
    private CachedEvent<TCachedEvent> _cachedEvent2 = CachedEvent.Empty<TCachedEvent>();

    public bool Cache(TEvent nextEvent)
    {
        switch (nextEvent)
        {
            case TCachedEvent cachedEvent:
                _cachedEvent2 = _cachedEvent1;
                _cachedEvent1 = CachedEvent.Cached(cachedEvent);
                return true;

            default:
                return false;
        }
    }

    public bool IsCached => _cachedEvent1.IsCached && _cachedEvent2.IsCached;

    public TCachedEvent? Event1 => _cachedEvent1.Event;
    public TCachedEvent? Event2 => _cachedEvent2.Event;
}

internal class EventCache2<TEvent, TCachedEvent1, TCachedEvent2>
    where TCachedEvent1 : TEvent
    where TCachedEvent2 : TEvent
{
    private CachedEvent<TCachedEvent1> _cachedEvent1 = CachedEvent.Empty<TCachedEvent1>();
    private CachedEvent<TCachedEvent2> _cachedEvent2 = CachedEvent.Empty<TCachedEvent2>();

    public bool Cache(TEvent nextEvent)
    {
        switch (nextEvent)
        {
            case TCachedEvent1 cachedEvent1:
                _cachedEvent1 = CachedEvent.Cached(cachedEvent1);
                return true;

            case TCachedEvent2 cachedEvent2:
                _cachedEvent2 = CachedEvent.Cached(cachedEvent2);
                return true;

            default:
                return false;
        }
    }

    public bool IsCached => _cachedEvent1.IsCached && _cachedEvent2.IsCached;

    public TCachedEvent1? Event1 => _cachedEvent1.Event;
    public TCachedEvent2? Event2 => _cachedEvent2.Event;
}

internal record CachedEvent<TEvent>(bool IsCached, TEvent? Event);

internal static class CachedEvent
{
    public static CachedEvent<TEvent> Empty<TEvent>() => new(false, default);
    public static CachedEvent<TEvent> Cached<TEvent>(TEvent cachedEvent) => new(true, cachedEvent);
}
