using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using KyivBeerNCode.Infrastructure.Persistence;

namespace KyivBeerNCode.Domain.Meetings
{
    [Export(typeof(MeetingRepository))]
    public class MeetingRepository
    {
        readonly IUnitOfWork _uow;

        [ImportingConstructor]
        public MeetingRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool ExisitsByTitle(string title)
        {
            return _uow.Query<Meeting>().Any(x => x.Title == title);
        }

        public void Add(Meeting meeting)
        {
            _uow.Add(meeting);
        }

        public IList<Meeting> GetAll()
        {
            return _uow.Query<Meeting>().ToList();
        }

        public Meeting GetByID(string id)
        {
            return _uow.Get<Meeting>(id);
        }
    }
}