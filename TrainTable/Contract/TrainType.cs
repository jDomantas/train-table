using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace TrainTable.Contract
{
    [JsonConverter(typeof(StringEnumConverter))]
    [Serializable]
    public enum TrainType
    {
        Electric,
        Diesel,
    }
}