namespace KyivBeerNCode
{
    public abstract class RootAggregate
    {
        public string ID { get; internal set; }

        protected void SetID(string id)
        {
            ID = id;
        }
    }
}
