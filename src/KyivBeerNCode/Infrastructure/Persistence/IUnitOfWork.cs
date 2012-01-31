using System.Linq;

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
