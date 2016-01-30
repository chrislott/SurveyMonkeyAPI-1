using SurveyMonkey.Containers;
using Newtonsoft.Json;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/batch/create_flow endpoint provided by Survey Monkey
    /// </summary>
    public class CreateFlowResponse
    {
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public CreateFlowResult FlowResult { get; set; }
    }
    public class CreateFlowResult
    {
        [JsonProperty(PropertyName = "survey", NullValueHandling = NullValueHandling.Ignore)]
        public SurveyInfo SurveyInfo { get; set; }

        [JsonProperty(PropertyName = "collector", NullValueHandling = NullValueHandling.Ignore)]
        public CollectorInfo CollectorInfo { get; set; }

        [JsonProperty(PropertyName = "email_message", NullValueHandling = NullValueHandling.Ignore)]
        public EmailMessageInfo EmailMessageInfo { get; set; }

        [JsonProperty(PropertyName = "recipients_report", NullValueHandling = NullValueHandling.Ignore)]
        public RecipientReportInfo RecipientReportInfo { get; set; }

        [JsonProperty(PropertyName = "redirect_url", NullValueHandling = NullValueHandling.Ignore)]
        public string RedirectURL { get; set; }
    }
}
