using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using KyivBeerNCode.Domain.Meetings;
using KyivBeerNCode.Infrastructure.Persistence.NHibernate;

namespace KyivBeerNCode
{
    public class ExecutionEnvironment
    {
        readonly CompositionContainer _container;

        public ExecutionEnvironment(Type uowType)
        {            
            var catalog = new TypeCatalog(
                // Infrastructure
                uowType,
                // Domain
                typeof(MeetingRegistrator), typeof(MeetingRepository));

            _container = new CompositionContainer(catalog);            
        }        

        public T Resolve<T>()
        {
            var export = _container.GetExports<T>().FirstOrDefault();
            if (export == null)
            {                
                throw new InvalidOperationException("Failed to build " + typeof(T));
                // http://blogs.msdn.com/b/dsplaisted/archive/2010/07/13/how-to-debug-and-diagnose-mef-failures.aspx :)
            }
            return export.Value;
        }

        public static ExecutionEnvironment Default()
        {
            return new ExecutionEnvironment(typeof(NHUnitOfWork));
        }
    }
}
