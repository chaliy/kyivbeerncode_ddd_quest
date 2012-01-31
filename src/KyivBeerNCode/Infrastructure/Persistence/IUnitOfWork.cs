using System.Linq;

namespace KyivBeerNCode.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        T Get<T>(string id) where T : RootAggregate;
        IQueryable<T> Query<T>() where T : RootAggregate;
        // This will physically delete entity, in most cases you
        // do not delete entities, you archive, move to recycle bin,        
        // even when you need delete, you probably better to mark it as deleted
        void Delete<T>(string id) where T : RootAggregate;
        void Add<T>(T entity) where T : RootAggregate;
        void CommitChanges();
    }
}
