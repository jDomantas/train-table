using Newtonsoft.Json;

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

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}
