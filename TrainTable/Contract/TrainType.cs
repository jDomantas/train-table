using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TrainTable.Contract
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TrainType
    {
        Electric,
        Diesel,
    }
}