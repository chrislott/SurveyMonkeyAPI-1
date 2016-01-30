using SurveyMonkey.Containers;
using Newtonsoft.Json;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/surveys/get_survey_list endpoint provided by Survey Monkey
    /// </summary>
    public class GetSurveyListResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public GetSurveyListResult SurveyListResult { get; set; }
    }

    public class GetSurveyListResult
    {
        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "page_size", NullValueHandling = NullValueHandling.Ignore)]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "surveys", NullValueHandling = NullValueHandling.Ignore)]
        public SurveyInfo[] SurveyList { get; set; }

        [JsonProperty(PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public SLMetaData MetaData { get; set; }
    }

    public class SLMetaData
    {
        [JsonProperty(PropertyName = "count", NullValueHandling = NullValueHandling.Ignore)]
        public int PageItemCount { get; set; }

        [JsonProperty(PropertyName = "total", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalItemCount { get; set; }

        [JsonProperty(PropertyName = "limit", NullValueHandling = NullValueHandling.Ignore)]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "offset", NullValueHandling = NullValueHandling.Ignore)]
        public int Offset { get; set; }

        [JsonProperty(PropertyName = "collaboration", NullValueHandling = NullValueHandling.Ignore)]
        public SLCollaboraton Collaboration { get; set; }
    }

    public class SLCollaboraton
    {
        [JsonProperty(PropertyName = "shared_by_total", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalShared { get; set; }

        [JsonProperty(PropertyName = "unfiled_owned_total", NullValueHandling = NullValueHandling.Ignore)]
        public int UnfiledTotal { get; set; }

        [JsonProperty(PropertyName = "shared_with_total", NullValueHandling = NullValueHandling.Ignore)]
        public int ShareTotal { get; set; }

        [JsonProperty(PropertyName = "owned_total", NullValueHandling = NullValueHandling.Ignore)]
        public int OwnedTotal { get; set; }
    }
}
