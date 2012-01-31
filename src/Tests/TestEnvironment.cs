using KyivBeerNCode.Infrastructure.Persistence.Memory;

namespace KyivBeerNCode.Tests
{
    public class TestEnvironment
    {        
        public static ExecutionEnvironment Create()
        {
            return new ExecutionEnvironment(typeof(DisposableMemoryUnitOfWork));
        }
    }    
}
