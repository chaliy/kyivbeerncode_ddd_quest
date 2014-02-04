using FluentAssertions;

namespace KyivBeerNCode.Domain.Meetings
{
    // This is more integration test as tests up to data access
    // In most cases for business logic you do not need such
    // At the same time, most of MY tests are such tests
    // Just because they are easy :)

	[Context]
    public class When_register_new_meeting : Specification
    {
		private MeetingRegistrator _registrator;
		private Meeting _justCreatedMeeting;

		protected override void Given()
		{
			_registrator = TestEnvironment.Create().Resolve<MeetingRegistrator>();
		}

		protected override void When()
		{
			_justCreatedMeeting = _registrator.Register("Fuuny Meeting");
		}

        [Then]
        public void Should_create_meeting()
        {
            _justCreatedMeeting.Should().NotBeNull();
        }
    }
}
 