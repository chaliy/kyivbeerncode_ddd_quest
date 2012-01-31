using System.Collections.Generic;
using KyivBeerNCode.Domain.Meetings;

namespace UI.Models.Meetings
{
    public class MeetingIndexModel
    {
        // Personally I am against using domain objects in views
        // For the meter of time, we do not have DTO, so consider
        // using domain object as temporary
        public IList<Meeting> Meetings { get; set; }
    }
}