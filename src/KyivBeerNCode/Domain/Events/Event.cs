using System.Collections.Generic;
using System.Linq;
using KyivBeerNCode.Infrastructure.Persistence;

namespace KyivBeerNCode.Domain.Events
{
    public class Event : RootAggregate
    {
        public string Title { get; internal set; }
        public Address Address { get; set; }
        public List<Attendie> Attendies { get; set; }

        public Event (string title)
	    {
            Title = title;
	    }
    }

    public class EventRegistrator
    {
        readonly EventRepository _events;

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

    public class EventRepository
    {
        IUnitOfWork _uow;

        public bool ExisitsByTitle(string title)
        {
            return _uow.Query<Event>().Any(x => x.Title == title);
        }

        internal void Add(Event @event)
        {
            _uow.Add(@event);
        }
    }

    public class Address : ValueObject
    {
        public string FacebookPage { get; set; }
    }

    public class Attendie : Entity
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
    }
}
