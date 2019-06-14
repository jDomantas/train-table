using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace TrainTable.Utils
{
    public static class CloningUtils
    {
        public static T DeepClone<T>(this T obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return default(T);
            }

            var settings = new JsonSerializerSettings();
            settings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj, settings), settings);
        }
    }
}
