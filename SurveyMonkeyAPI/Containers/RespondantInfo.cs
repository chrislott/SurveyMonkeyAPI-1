using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace SurveyMonkey.Containers
{
    public class RespondentInfo : BaseContainer
    {
        [JsonProperty(PropertyName = "respondent_id", Required = Required.Always)]
        public string RespondentID { get; set; }

        [JsonProperty(PropertyName = "date_start", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DateStart { get; set; }

        [JsonProperty(PropertyName = "collector_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CollectorID { get; set; }

        [JsonProperty(PropertyName = "collection_mode", NullValueHandling = NullValueHandling.Ignore)]
        public RespondentCollectionModeEnum CollectionMode { get; set; }

        [JsonProperty(PropertyName = "custom_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomID { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "ip_address", NullValueHandling = NullValueHandling.Ignore)]
        public string IPAddress { get; set; }

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public RespondentStatusEnum ResponseStatus { get; set; }

        [JsonProperty(PropertyName = "analysis_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AnalysisURL { get; set; }

        [JsonProperty(PropertyName = "recipient_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientID { get; set; }
    }
}
