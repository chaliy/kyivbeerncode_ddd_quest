using System.Collections.Generic;

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
}
