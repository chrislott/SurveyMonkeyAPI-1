using Newtonsoft.Json;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/surveys/get_response_counts endpoint provided by Survey Monkey
    /// </summary>
    public class GetResponseCountsResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public GetResponseCountsResult ResponseCountResult { get; set; }
    }

    public class GetResponseCountsResult
    {
        [JsonProperty(PropertyName = "completed", Required = Required.Always)]
        public int NumberCompleted { get; set; }

        [JsonProperty(PropertyName = "started", Required = Required.Always)]
        public int NumberStarted { get; set; }
    }
}
