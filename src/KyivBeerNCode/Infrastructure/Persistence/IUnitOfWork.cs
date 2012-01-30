using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KyivBeerNCode.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        T Get<T>(string key);
        IQueryable<T> Query<T>();
        void Delete<T>(string key);
        void Add<T>(T entity);
        void CommitChanges();
    }
}
