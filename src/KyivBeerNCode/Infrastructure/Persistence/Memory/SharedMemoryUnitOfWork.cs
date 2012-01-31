using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace KyivBeerNCode.Infrastructure.Persistence.Memory
{
    [Export(typeof(IUnitOfWork))]
    public class SharedMemoryUnitOfWork : AbstractMemoryUnitOfWork
    {
        readonly static IList<RootAggregate> Store = new List<RootAggregate>();
        public SharedMemoryUnitOfWork()
            : base(Store)
        {
        }
    }
}
