using Newtonsoft.Json;
using SurveyMonkey.Containers;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/surveys/get_respondent_list endpoint provided by Survey Monkey
    /// </summary>
    public class GetRespondentListResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public GetRespondentListResult RespondantListResult { get; set; }

        [JsonProperty(PropertyName = "upgrade_info", NullValueHandling = NullValueHandling.Ignore)]
        public UpgradeInfo UpgradeInfomation { get; set; }
    }
    public class GetRespondentListResult
    {
        [JsonProperty(PropertyName = "page", Required = Required.Always)]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "page_size", Required = Required.Always)]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "respondents", Required = Required.Always)]
        public RespondentInfo[] RespondantList { get; set; }
    }
}
