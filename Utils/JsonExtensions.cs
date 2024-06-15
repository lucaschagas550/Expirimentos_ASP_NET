using System.Text.Json;
using System.Text;

namespace TestTabelaResponivaBoostrap.Utils
{
    public static class JsonExtensions
    {
        public static StringContent SerializeObject(object data) =>
          new StringContent(
              JsonSerializer.Serialize(data),
              Encoding.UTF8,
              "application/json");

        public static async Task<T?> DeserializeObject<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        public static string SerializeObjectToJson(object data) =>
            JsonSerializer.Serialize(data);

        public static T? DeserializeJsonToObject<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}
