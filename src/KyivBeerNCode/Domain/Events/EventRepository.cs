using System.ComponentModel.Composition;
using System.Linq;
using KyivBeerNCode.Infrastructure.Persistence;

namespace KyivBeerNCode.Domain.Events
{
    [Export(typeof(EventRepository))]
    public class EventRepository
    {
        readonly IUnitOfWork _uow;

        [ImportingConstructor]
        public EventRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool ExisitsByTitle(string title)
        {
            return _uow.Query<Event>().Any(x => x.Title == title);
        }

        internal void Add(Event @event)
        {
            _uow.Add(@event);
        }
    }
}