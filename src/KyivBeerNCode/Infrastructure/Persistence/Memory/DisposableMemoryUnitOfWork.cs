using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace KyivBeerNCode.Infrastructure.Persistence.Memory
{
    [Export(typeof(IUnitOfWork))]
    public class DisposableMemoryUnitOfWork : AbstractMemoryUnitOfWork
    {
        public DisposableMemoryUnitOfWork() : base(new List<RootAggregate>())
        {
        }
    }
}
