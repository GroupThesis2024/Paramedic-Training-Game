namespace Backend
{
    public abstract class Condition
    {
        private BodyLocation bodyLocation;

        protected Condition(BodyLocation bodyLocation)
        {
            this.bodyLocation = bodyLocation;
        }

        public void SetBodyLocation(BodyLocation value)
        {
            bodyLocation = value;
        }

        public BodyLocation GetBodyLocation()
        {
            return bodyLocation;
        }
    }
}