using System.ComponentModel.Composition;

namespace KyivBeerNCode.Domain.Events
{
    [Export(typeof(EventRegistrator))]
    public class EventRegistrator
    {
        readonly EventRepository _events;

        [ImportingConstructor] 
        public EventRegistrator(EventRepository events)
        {
            _events = events;
        }

        public Event Register(string title)
        {
            if (_events.ExisitsByTitle(title))
            {
                throw new DomainException("Event with title " + title + " already exists");
            }

            var @event = new Event(title);
            _events.Add(@event);

            return @event;
        }
    }
}