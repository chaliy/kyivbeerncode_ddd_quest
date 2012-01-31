using KyivBeerNCode.Infrastructure.Persistence.Memory;

namespace KyivBeerNCode.Tests
{
    public class TestEnvironment
    {        
        public static ExecutionEnvironement Create()
        {
            return new ExecutionEnvironement(typeof (MemoryUnitOfWork));
        }
    }    
}
