using System.Collections.Generic;
using System.Linq;

namespace KyivBeerNCode.Infrastructure.Persistence.Memory
{
    public abstract class AbstractMemoryUnitOfWork : IUnitOfWork
    {
        readonly IList<RootAggregate> _store;

        protected AbstractMemoryUnitOfWork(IList<RootAggregate> store)
        {
            _store = store;
        }

        public T Get<T>(string id) where T : RootAggregate
        {
            return _store.OfType<T>().First(x => x.ID == id);
        }

        public IQueryable<T> Query<T>() where T : RootAggregate
        {
            return _store.OfType<T>().AsQueryable();
        }

        public void Delete<T>(string id) where T : RootAggregate
        {
            var toDelete = _store.OfType<T>().First(x => x.ID == id);

            if (toDelete != null)
            {
                _store.Remove(toDelete);
            }
        }

        public void Add<T>(T entity) where T : RootAggregate
        {
            _store.Add(entity);
        }

        public void CommitChanges()
        {
            // Do nothing for now
        }
    }
}
