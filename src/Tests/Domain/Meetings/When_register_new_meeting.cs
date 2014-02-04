using FluentAssertions;
using KyivBeerNCode.Domain.Meetings;
using NUnit.Framework;

namespace KyivBeerNCode.Tests.Domain.Meetings
{
    // This is more integration test as tests up to data access
    // In most cases for business logic you do not need such
    // At the same time, most of MY tests are such tests
    // Just because they are easy :)
    public class When_register_new_meeting
    {
        private KyivBeerNCode.Domain.Meetings.Meeting _justCreatedMeeting;

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
