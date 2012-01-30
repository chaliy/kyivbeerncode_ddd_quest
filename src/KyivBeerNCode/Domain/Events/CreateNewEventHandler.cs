using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KyivBeerNCode.Domain.Events
{
    public class CreateNewEvent
    {
        public string Title { get; set; }
    }

    public class CreateNewEventHandler
    {
        public void Handle(CreateNewEvent cmd) 
        {
        }
    }
}
