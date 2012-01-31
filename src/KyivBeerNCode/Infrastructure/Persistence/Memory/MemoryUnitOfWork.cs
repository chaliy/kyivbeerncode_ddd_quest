using System.ComponentModel.Composition;
using System.Linq;

namespace KyivBeerNCode.Infrastructure.Persistence.Memory
{
    [Export(typeof(IUnitOfWork))]
    public class MemoryUnitOfWork : IUnitOfWork
    {
        public T Get<T>(string key)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Query<T>()
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(string key)
        {
            throw new System.NotImplementedException();
        }

        public void Add<T>(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void CommitChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
