using Newtonsoft.Json;
using SurveyMonkey.Containers;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/templates/get_template_list endpoint provided by Survey Monkey
    /// </summary>
    public class GetTemplateListResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public GetTemplateListResult TemplateListResult { get; set; }

        [JsonProperty(PropertyName = "upgrade_info", NullValueHandling = NullValueHandling.Ignore)]
        public UpgradeInfo UpgradeInfomation { get; set; }
    }

    public class GetTemplateListResult
    {
        [JsonProperty(PropertyName = "page", Required = Required.Always)]
        public int Page { get; set; }

        [JsonProperty(PropertyName = "page_size", Required = Required.Always)]
        public int PageSize { get; set; }

        [JsonProperty(PropertyName = "templates", Required = Required.Always)]
        public TemplateInfo[] TemplateInfoList { get; set; }
    }
}
