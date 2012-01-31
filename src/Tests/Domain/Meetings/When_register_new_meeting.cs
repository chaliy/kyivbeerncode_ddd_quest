using FluentAssertions;
using KyivBeerNCode.Domain.Meetings;
using NUnit.Framework;

namespace KyivBeerNCode.Tests.Domain.Meetings
{
    public class When_register_new_meeting
    {
        private Meeting _justCreatedMeeting;

        [TestFixtureSetUp]
        public void Given_newelly_create_meeting()
        {
            var env = TestEnvironment.Create();
            var registrator = env.Resolve<MeetingRegistrator>();

            _justCreatedMeeting = registrator.Register("Fuuny Meeting");
        }

        [Test]
        public void Should_create_meeting()
        {
            _justCreatedMeeting.Should().NotBeNull();
        }
    }
}
