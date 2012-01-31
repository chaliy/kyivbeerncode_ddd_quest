using KyivBeerNCode.Infrastructure.Persistence.Memory;

namespace KyivBeerNCode
{
    public class TestEnvironment
    {        
        public static ExecutionEnvironment Create()
        {
            return new ExecutionEnvironment(typeof (MemoryUnitOfWork));
        }
    }    
}
