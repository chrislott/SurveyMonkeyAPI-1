using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SurveyMonkey.Containers
{
    public class CollectorInfo : BaseContainer
    {
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public CollectorTypeEnum? Type { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "open", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Open { get; set; }

        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public string URL { get; set; }

        [JsonProperty(PropertyName = "collector_id", Required = Required.Always)]
        public int? CollectorID { get; set; }

        [JsonProperty(PropertyName = "send", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Send { get; set; }

        [JsonProperty(PropertyName = "recipients", NullValueHandling = NullValueHandling.Ignore)]
        public RecipientInfo[] Recipients { get; set; }
    }
}
