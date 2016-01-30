using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    public class EmailMessageInfo
    {
        [JsonProperty(PropertyName = "reply_email", NullValueHandling = NullValueHandling.Ignore)]
        public string ReplyEmail { get; set; }

        [JsonProperty(PropertyName = "subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "body_text", NullValueHandling = NullValueHandling.Ignore)]
        public string BodyText { get; set; }

        [JsonProperty(PropertyName = "email_message_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmailMessageID { get; set; }

        [JsonProperty(PropertyName = "disable_footer", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisableFooter { get; set; }
    }

}
