using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Backend
{
    public class IPatientConverter : JsonConverter<IPatient>
    {
        public override IPatient ReadJson(
            JsonReader reader, Type objectType,
            IPatient existingValue, bool hasExistingValue, JsonSerializer serializer
        )
        {
            JObject jsonObject = JObject.Load(reader);

            if (jsonObject.ContainsKey("name"))
            {
                return jsonObject.ToObject<Patient>();
            }

            throw new Exception("Key not found in Patient");
        }

        public override void WriteJson(JsonWriter writer, IPatient value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}