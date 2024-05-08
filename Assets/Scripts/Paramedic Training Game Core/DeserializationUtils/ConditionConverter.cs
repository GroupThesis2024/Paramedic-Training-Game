using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Backend
{
    public class ConditionConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings()
        {
            ContractResolver = new ConditionSpecifiedConcreteClassConverter()
        };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Condition);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            JObject jsonObject = JObject.Load(reader);
            switch (jsonObject["condition"].Value<int>())
            {
                case 1:
                    return JsonConvert.DeserializeObject<BleedingMajor>(jsonObject.ToString(), SpecifiedSubclassConversion);
                case 2:
                    return JsonConvert.DeserializeObject<BleedingMinor>(jsonObject.ToString(), SpecifiedSubclassConversion);
                case 3:
                    return JsonConvert.DeserializeObject<Concussion>(jsonObject.ToString(), SpecifiedSubclassConversion);
                case 4:
                    return JsonConvert.DeserializeObject<Fracture>(jsonObject.ToString(), SpecifiedSubclassConversion);
                case 5:
                    return JsonConvert.DeserializeObject<Shock>(jsonObject.ToString(), SpecifiedSubclassConversion);
                case 6:
                    return JsonConvert.DeserializeObject<Whiplash>(jsonObject.ToString(), SpecifiedSubclassConversion);
                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }
    }
}