using System.Text.Json;

namespace KafkaExample.Domain.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object data)
        {
            return JsonSerializer.Serialize(data);
        }

        public static T Parse<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
