using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KyivBeerNCode.Infrastructure.Persistence.NHibernate
{
    class NHUnitOfWork : IUnitOfWork
    {
        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>()
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Add<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void CommitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
