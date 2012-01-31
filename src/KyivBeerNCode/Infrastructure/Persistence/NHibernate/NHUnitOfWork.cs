using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace KyivBeerNCode.Infrastructure.Persistence.NHibernate
{
    [Export(typeof(IUnitOfWork))]
    public class NHUnitOfWork : IUnitOfWork
    {
        public T Get<T>(string id) where T : RootAggregate
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : RootAggregate
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(string id) where T : RootAggregate
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity) where T : RootAggregate
        {
            throw new NotImplementedException();
        }

        public void CommitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
