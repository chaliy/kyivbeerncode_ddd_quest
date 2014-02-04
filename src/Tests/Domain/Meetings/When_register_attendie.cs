using FluentAssertions;

namespace KyivBeerNCode.Domain.Meetings
{
    // Regular test, this is how you test logic

	[Context]
    public class When_register_attendie : Specification
    {
        private Meeting _meeting;

		protected override void Given()
		{
			_meeting = new Meeting("DDD Quest Meeting");
		}

		protected override void When()
		{
			_meeting.RegisterAttendie("Ivan Korneliuk");
		}

        [Then]
        public void Should_register_attendie()
        {
            _meeting.IsAttendieRegistered("Ivan Korneliuk").Should().BeTrue();
        }
    }
}
