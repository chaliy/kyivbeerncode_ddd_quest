using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel.Configuration;
using System.Text;
using System.Xml;
using FluentAssertions;
using NUnit.Framework;

namespace KyivBeerNCode.Tests.Domain
{
    public class DomainModelTests
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
        // todo: should add req about warening when register twice
        [Test]
        public void should_not_allow_to_register_when_cancelled()
        {
            // arrange
            var notifier = new MockNotifier();
            var meeting = new Meeting(1);

            // act
            meeting.Cancel(notifier);

            // assert
            Assert.Throws<MeetingCanceledException>(() => meeting.AddAttendee(new Attendee("foo")));
        }

        [Test]
        public void should_notify_all_attendees_when_canceled()
        {
            // arrange
            var notifier = new MockNotifier();
            var meeting = new Meeting(2);
            var attendees = new []{"m1", "m2"}.Select(m => meeting.CreateAndAddAttendee(m)).ToList();
            attendees.ForEach(meeting.AddAttendee);

            // act
            meeting.Cancel(notifier);

            // assert
            Assert.That(notifier.CalledAttendees, Is.EqualTo(attendees));
        }

        [Test]
        public void foo()
        {
            var meeting = new Meeting(2);

            var dataContractSerializer = new DataContractSerializer(typeof(Fooo));
            var stringBuilder = new StringBuilder();
            dataContractSerializer.WriteObject(new XmlTextWriter(new StringWriter(stringBuilder)), new Fooo{foo = "sdfsd"});

            Console.Out.WriteLine("stringBuilder = {0}", stringBuilder);
        }
    }
    public class Fooo
    {
        public string foo { get; set; }
    }

    public class MockNotifier : INotifier
    {
        public List<Attendee> CalledAttendees { get; private set; }
        public void Notify(IEnumerable<Attendee> attendies)
        {
            CalledAttendees = attendies.ToList();
        }
    }

    public interface INotifier
    {
        void Notify(IEnumerable<Attendee> attendies);
    }

    public class MeetingCanceledException : Exception
    {
    }

    public class Meeting
    {

        private bool isCanceled;
        public int MaximumNumberOfAttendies { get; private set; }

        public List<Attendee> Attendies { get; private set; }

        public Meeting(int maximumNumberOfAttendies)
        {
            Attendies = new List<Attendee>();
            MaximumNumberOfAttendies = maximumNumberOfAttendies;
        }

        public void AddAttendee(Attendee attendee)
        {
            if (isCanceled)
            {
                throw new MeetingCanceledException();
            }
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

        public void Cancel(INotifier notifier)
        {
            isCanceled = true;
            notifier.Notify(Attendies);
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

        public static Attendee CreateAndAddAttendee(this Meeting meeting, string email)
        {
            var atendee = new Attendee(email);
            meeting.AddAttendee(atendee);
            return atendee;
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
