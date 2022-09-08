using Newtonsoft.Json;
using System.ComponentModel;

namespace T20.Content.Models
{
    public class Entity
    {
         [JsonProperty("data", Required = Required.Always)]
         public virtual dynamic Data { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

         [JsonIgnore]
        [JsonProperty("partitionKey", Required = Required.Always)]
        public string PartitionKey { get; set; }

         [JsonProperty("type", Required = Required.Always)]
         public string Type { get; set; }

         [JsonIgnore]
        [JsonProperty("visible", Required = Required.Always)]
        public bool Visible { get; set; }

         [JsonIgnore]
         [JsonProperty("workflow", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
         public Workflow Workflow { get; set; } = new Workflow();

         [JsonIgnore]
         [JsonProperty("_rid", NullValueHandling = NullValueHandling.Ignore)]
         public string Rid { get; set; }

         [JsonIgnore]
         [JsonProperty("_self", NullValueHandling = NullValueHandling.Ignore)]
         public string Self { get; set; }

         [JsonIgnore]
         [JsonProperty("_etag", NullValueHandling = NullValueHandling.Ignore)]
         public string Etag { get; set; }

         [JsonIgnore]
        [DefaultValue("attachments/")]
         [JsonProperty("_attachments", NullValueHandling = NullValueHandling.Ignore)]
         public string Attachments { get; set; }

         [JsonIgnore]
         [JsonProperty("_ts", NullValueHandling = NullValueHandling.Ignore)]
         public int? Ts { get; set; }
    }
}
