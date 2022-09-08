using Newtonsoft.Json;
using T20.Content.Extensions;

namespace T20.Content.Models
{
    public partial class Workflow
    {
        [JsonProperty("id", Required = Required.Always)]
        [JsonConverter(typeof(StringRequiredConverter))]
        public string Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        [JsonConverter(typeof(StringRequiredConverter))]
        public string Name { get; set; }

        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public Workflow Parent { get; set; }
    }
}
