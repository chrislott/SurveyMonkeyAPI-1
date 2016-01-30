using Newtonsoft.Json;
using SurveyMonkey.Containers;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/surveys/get_responses endpoint provided by Survey Monkey
    /// </summary>
    public class GetResponsesResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public GetResponsesResult[] ResponseResultList { get; set; }
    }

    public class GetResponsesResult
    {
        [JsonProperty(PropertyName = "respondent_id", Required = Required.Always)]
        public string RespondentID { get; set; }

        [JsonProperty(PropertyName = "questions", NullValueHandling = NullValueHandling.Ignore)]
        public QuestionInfo[] QuestionList { get; set; }
    }
}
