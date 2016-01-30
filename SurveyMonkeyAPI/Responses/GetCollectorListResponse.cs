using Newtonsoft.Json;
using SurveyMonkey.Containers;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/surveys/get_collector_list endpoint provided by Survey Monkey
    /// </summary>
    public class GetCollectorListResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public GetCollectorListResult CollectorListResult { get; set; }
    }

    public class GetCollectorListResult
    {
        [JsonProperty(PropertyName = "page", Required = Required.Always)]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "page_size", Required = Required.Always)]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "collectors", Required = Required.Always)]
        public CollectorInfo[] CollectorList { get; set; }
    }
}
