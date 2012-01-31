using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace KyivBeerNCode.Tests.Domain
{
    public class DomainModel
    {
        [Test]
        public void should_prohitbit_to_add_attendie_when_maximum_allowed_is_zero()
        {
            // arrange / act
            var maximumNumberOfAttendies = 0;
            var meeting = new Meeting(maximumNumberOfAttendies);

            // assert
            Assert.Throws<NumberOfAttendiesExceeded>(() => meeting.CreateAndAddAttendee());
        }

        [Test]
        public void should_prohibit_adding_more_then_max_numer_of_attendies()
        {
            // arrange
            var maximumNumberOfAttendies = 2;
            var meeting = new Meeting(maximumNumberOfAttendies);

            // act
            meeting.CreateAndAddAttendee();
            meeting.CreateAndAddAttendee();

            // assert
            Assert.Throws<NumberOfAttendiesExceeded>(() => meeting.CreateAndAddAttendee());
        }

        [Test]
        public void should_add_attendee()
        {
            // arrange
            var maximumNumberOfAttendies = 2;
            var meeting = new Meeting(maximumNumberOfAttendies);
            // act
            var attendee = meeting.CreateAndAddAttendee();

            // assert
            meeting.Attendies.Should().Contain(attendee);
        }

        [Test]
        public void should_not_register_the_same_atendee_twice()
        {
            //arrange
            var meeting = new Meeting(42);

            //act
            meeting.CreateAndAddAttendee("anton@gmail.com");
            meeting.CreateAndAddAttendee("anton@gmail.com");
            //assert
            Assert.That(meeting.Attendies.Count, Is.EqualTo(1));
        }

        [Test]
        public void shoud_not_throw_when_limit_not_exceeded()
        {
            //arrange
            var meeting = new Meeting(1);

            //act
            meeting.CreateAndAddAttendee("anton@gmail.com");
            meeting.CreateAndAddAttendee("anton@gmail.com");

            //assert
            Assert.That(meeting.Attendies.Count, Is.EqualTo(1));
        }

        [Test]
        public void should_notify_attendees_when_cancelled()
        {
            // arrange
            
            // assert
        }
    }

    public class Meeting
    {
        public int MaximumNumberOfAttendies { get; private set; }

        public List<Attendee> Attendies { get; private set; }

        public Meeting(int maximumNumberOfAttendies)
        {
            Attendies = new List<Attendee>();
            MaximumNumberOfAttendies = maximumNumberOfAttendies;
        }

        public void AddAttendee(Attendee attendee)
        {
            if (Attendies.Any(x => x.Email == attendee.Email))
            {
                return;
            }
            if (Attendies.Count >= MaximumNumberOfAttendies)
            {
                throw new NumberOfAttendiesExceeded();
            }
            Attendies.Add(attendee);
        }
    }

    public class AtendeeAlreadyRegisteredException : Exception
    {
    }

    public static class MeetingExtensions
    {
        public static Attendee CreateAndAddAttendee(this Meeting meeting)
        {
            var atendee = new Attendee(Guid.NewGuid() + "dummy@gmail.com");
            meeting.AddAttendee(atendee);
            return atendee;
        }

        public static void CreateAndAddAttendee(this Meeting meeting, string email)
        {
            meeting.AddAttendee(new Attendee(email));
        }
    }

    public class Attendee
    {
        public string Email { get; set; }

        public Attendee(string email)
        {
            Email = email;
        }
    }

    public class NumberOfAttendiesExceeded : Exception
    {
    }
}
