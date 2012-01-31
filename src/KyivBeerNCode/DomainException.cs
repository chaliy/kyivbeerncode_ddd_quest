using System;

namespace KyivBeerNCode
{
    public class DomainException : Exception
    {        
        public DomainException(string msg) : base(msg)
        {            
        }
    }
}
