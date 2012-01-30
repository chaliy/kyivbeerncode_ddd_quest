using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KyivBeerNCode
{
    public abstract class RootAggregate
    {
        public string ID { get; internal set; }
    }    

    public abstract class ValueObject
    {        
    }

    public abstract class Entity
    {
    }
}
