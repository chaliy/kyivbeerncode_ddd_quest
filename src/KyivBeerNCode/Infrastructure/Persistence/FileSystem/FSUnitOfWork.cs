using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace KyivBeerNCode.Infrastructure.Persistence.FileSystem
{
    public class FSUnitOfWork : IUnitOfWork
    {
        private readonly string _folder;

        private void Serialize<T>(T input, string key)
        {
            var ser = new DataContractSerializer(typeof(T));
            var mem = new MemoryStream();
            ser.WriteObject(mem, input);

//            File.WriteAllBytes(Path.Combine(key, ));
        }

        public T Get<T>(string id) where T : RootAggregate
        {
            return default(T);
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
