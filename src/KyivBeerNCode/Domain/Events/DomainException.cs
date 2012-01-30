using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KyivBeerNCode.Domain.Events
{
    class DomainException : Exception
    {        
        public DomainException(string msg) : base(msg)
        {            
        }
    }
}
