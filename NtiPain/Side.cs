using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NtiPain
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Side: int
    {
        Right,
        Left
    }
}