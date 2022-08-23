using Newtonsoft.Json;

namespace T20.Content.Models
{
    public class ResponseMessage
    {
        [JsonRequired]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
