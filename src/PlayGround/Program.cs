using KyivBeerNCode;
using KyivBeerNCode.Domain.Events;

namespace PlayGround
{    
    class Program
    {
        static void Main(string[] args)
        {
            var env = ExecutionEnvironement.Default();
            var registrator = env.Resolve<EventRegistrator>();

            var @event = registrator.Register("Test");
        }
    }
}
