
using Newtonsoft.Json;
using System.Collections.Generic;

namespace T20.Content.Models
{
    public partial class TeamPageEnvelope : Entity
    {
        [JsonProperty("data", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public new TeamPage Data { get; set; }

        public partial class TeamPage
        {
            [JsonProperty("ContentTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public int? ContentTypeId { get; set; }

            [JsonProperty("Properties", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public ICollection<Property> Properties { get; set; }

            [JsonProperty("Name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty("Id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public int? Id { get; set; }

            [JsonProperty("Key", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public string Key { get; set; }

        }

        public partial class Property
        {
            [JsonProperty("Values", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public ICollection<Values> Values { get; set; }

            [JsonProperty("Alias", Required = Required.Always)]
            public string Alias { get; set; }

            [JsonProperty("Id", Required = Required.Always)]
            public int Id { get; set; }

            [JsonProperty("Key", Required = Required.Always)]
            public string Key { get; set; }
        }

        public partial class Values
        {
            [JsonProperty("EditedValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public object EditedValue { get; set; }

            [JsonProperty("PublishedValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
            public object PublishedValue { get; set; }
        }
    }
}