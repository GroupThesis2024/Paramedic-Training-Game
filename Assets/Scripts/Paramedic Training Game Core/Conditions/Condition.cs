using Newtonsoft.Json;

namespace Backend
{
    [JsonConverter(typeof(ConditionConverter))]
    public abstract class Condition
    {
        [JsonProperty]
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

        public string GetConditionName()
        {
            string conditionName = GetType().Name;
            return conditionName;
        }
    }
}