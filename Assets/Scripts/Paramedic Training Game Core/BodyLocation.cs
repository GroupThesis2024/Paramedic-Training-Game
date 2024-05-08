using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Backend
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BodyLocation
    {
        Body,
        Head,
        Neck,
        Shoulders,
        LeftArm,
        LeftFingers,
        LeftLeg,
        None,
        RightArm,
        RightFingers,
        RightLeg,
    }
}