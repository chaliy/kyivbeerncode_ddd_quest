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

        internal void Add(Meeting meeting)
        {
            _uow.Add(meeting);
        }
    }
}