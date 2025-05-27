using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Luftborn.SharedKernel.Middlewares.Handlers
{
    public class JsonHandler
    {
        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }

        public static T Deserialize<T>(string jsonObj) where T : class
        {
            return JsonConvert.DeserializeObject<T>(jsonObj, jsonSerializerSettings);
        }

        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
    }
}
