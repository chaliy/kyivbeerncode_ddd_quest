using System;
using FluentAssertions;
using KyivBeerNCode.Domain.Meetings;
using NUnit.Framework;

namespace KyivBeerNCode.Tests.Domain.Meetings
{
    public class When_register_alread_registerd_attendie
    {
        private Meeting _meeting;
        private Action _register;

        [TestFixtureSetUp]
        public void Given_meeting_and_attendie()
        {
            _meeting = new Meeting("DDD Quest Meeting");
            _meeting.RegisterAttendie("Ivan Korneliuk");

            // Act

            _register = () => _meeting.RegisterAttendie("Ivan Korneliuk");
        }

        [Test]
        public void Should_prohibit_double_registration()
        {
            _register.ShouldThrow<DomainException>();
        }
    }
}
