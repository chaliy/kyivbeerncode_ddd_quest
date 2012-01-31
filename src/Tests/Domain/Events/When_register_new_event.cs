using FluentAssertions;
using KyivBeerNCode.Domain.Events;
using NUnit.Framework;

namespace KyivBeerNCode.Tests.Domain.Events
{
    public class When_register_new_event
    {
        private Event _justCreatedEvent;

        [TestFixtureSetUp]
        public void Given_newelly_create_event()
        {
            var env = TestEnvironment.Create();
            var registrator = env.Resolve<EventRegistrator>();

            _justCreatedEvent = registrator.Register("Fuuny Event");
        }

        [Test]
        public void Should_create_event()
        {
            _justCreatedEvent.Should().NotBeNull();
        }
    }
}
