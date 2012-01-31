using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KyivBeerNCode.Utils;

namespace KyivBeerNCode.Domain.Meetings
{
    public class Meeting : RootAggregate
    {
        public string Title { get; internal set; }
        public Address Address { get; internal set; }
        List<Attendie> _attendies = new List<Attendie>();
        public ReadOnlyCollection<Attendie> Attendies
        {
            get { return _attendies.AsReadOnly(); }
        }

        public Meeting (string title)
	    {
            Title = title;
            SetID(GenerateId(title));
	    }

        public Attendie RegisterAttendie(string name)
        {
            var attendie = new Attendie(name);
            _attendies.Add(attendie);
            return attendie;
        }

        public bool IsAttendieRegistered(string attendie)
        {
            return _attendies.Any(x => x.FullName == attendie);
        }

        public static string GenerateId(string title)
        {
            return Urls.MakeToken(title);
        }
    }
}
