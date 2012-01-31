using FluentAssertions;
using KyivBeerNCode.Domain.Meetings;
using NUnit.Framework;

namespace KyivBeerNCode.Tests.Domain.Meetings
{
    // Regular test, this is how you test logic
    public class When_register_attendie
    {
        private Meeting _meeting;
        private Attendie _attendie;

        [TestFixtureSetUp]
        public void Given_meeting_and_attendie()
        {
            _meeting = new Meeting("DDD Quest Meeting");

            // Act
            _attendie = _meeting.RegisterAttendie("Ivan Korneliuk");
        }

        [Test]
        public void Should_register_attendie()
        {
            _meeting.IsAttendieRegistered("Ivan Korneliuk").Should().BeTrue();
        }
    }
}
