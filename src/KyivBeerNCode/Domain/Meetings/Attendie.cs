namespace KyivBeerNCode.Domain.Meetings
{
    public class Attendie : Entity
    {
        public Attendie(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; internal set; }
        public string EmailAddress { get; set; }
    }
}