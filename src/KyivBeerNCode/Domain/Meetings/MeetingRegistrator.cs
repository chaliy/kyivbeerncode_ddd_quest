using System.ComponentModel.Composition;

namespace KyivBeerNCode.Domain.Meetings
{
    [Export(typeof(MeetingRegistrator))]
    public class MeetingRegistrator
    {
        readonly MeetingRepository _meetings;

        [ImportingConstructor] 
        public MeetingRegistrator(MeetingRepository meetings)
        {
            _meetings = meetings;
        }

        public Meeting Register(string title)
        {
            if (_meetings.ExisitsByTitle(title))
            {
                throw new DomainException("Event with title " + title + " already exists");
            }

            var @event = new Meeting(title);
            _meetings.Add(@event);

            return @event;
        }
    }
}