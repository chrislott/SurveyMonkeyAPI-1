using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    public class RecipientInfo
    {
        [JsonProperty(PropertyName = "recipient_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientID { get; set; }

        [JsonProperty(PropertyName = "custom_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomID { get; set; }

        [JsonProperty(PropertyName = "first_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name", NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string EMail { get; set; }
    }

    public class RecipientReportInfo
    {
        [JsonProperty(PropertyName = "valid_emails_count", NullValueHandling = NullValueHandling.Ignore)]
        public int ValidEmailCount { get; set; }

        [JsonProperty(PropertyName = "invalid_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] InvalidEmailAddressList { get; set; }

        [JsonProperty(PropertyName = "duplicate_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] DuplicateEmailAddressList { get; set; }

        [JsonProperty(PropertyName = "bounced_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] BouncedEmailAddressList { get; set; }

        [JsonProperty(PropertyName = "optedout_emails", NullValueHandling = NullValueHandling.Ignore)]
        public string[] OptedOutEmailAddressList { get; set; }

        [JsonProperty(PropertyName = "recipients", NullValueHandling = NullValueHandling.Ignore)]
        public RecipientInfo[] RecipientList { get; set; }
    }

}
