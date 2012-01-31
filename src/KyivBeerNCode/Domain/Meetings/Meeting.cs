using System.Collections.Generic;

namespace KyivBeerNCode.Domain.Meetings
{
    public class Meeting : RootAggregate
    {
        public string Title { get; internal set; }
        public Address Address { get; set; }
        public List<Attendie> Attendies { get; set; }

        public Meeting (string title)
	    {
            Title = title;
	    }
    }
}
