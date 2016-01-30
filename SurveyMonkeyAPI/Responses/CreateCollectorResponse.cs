using SurveyMonkey.Containers;
using Newtonsoft.Json;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response for endpoint https://api.surveymonkey.net/v2/batch/create_flow from SurveyMonkey
    /// </summary>
    public class CreateCollectorResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public CreateCollectorResult CollectorResult { get; set; }
    }

    public class CreateCollectorResult
    {
        [JsonProperty(PropertyName = "collector", NullValueHandling = NullValueHandling.Ignore)]
        public CollectorInfo Collector { get; set; }
    }

}
