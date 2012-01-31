using System;

using FluentAssertions;

namespace KyivBeerNCode.Domain.Meetings
{
	[Exceptional, Context]
    public class When_register_already_registered_attendie : Specification
    {
        Meeting _meeting;

		public When_register_already_registered_attendie()
		{
			Expect<DomainException>();
		}

		protected override void Given()
		{
			_meeting = new Meeting("DDD Quest Meeting");
			_meeting.RegisterAttendie("Ivan Korneliuk");
		}

		protected override void When()
		{
			_meeting.RegisterAttendie("Ivan Korneliuk");
		}

        [Then]
        public void An_exception_should_be_thrown()
        {
        	var exception = Thrown<DomainException>();

			// assert any exception details here
			exception.Message.Should().NotBeEmpty();
        }
    }
}
