using SurveyMonkey.Containers;
using Newtonsoft.Json;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/surveys/get_survey_details endpoint provided by Survey Monkey
    /// </summary>
    public class GetSurveyDetailsResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public SurveyTInfo SurveyDetailsResult { get; set; }
    }

    //public class GetSurveyDetailsResult : BaseContainer
    //{
    //    [JsonProperty(PropertyName = "custom_variable_count", NullValueHandling = NullValueHandling.Ignore)]
    //    public int CustomVariableCount { get; set; }

    //    [JsonProperty(PropertyName = "custom_variables", NullValueHandling = NullValueHandling.Ignore)]
    //    public CustomVariableInfo[] CustomVariableList { get; set; }

    //    [JsonProperty(PropertyName = "language_id", NullValueHandling = NullValueHandling.Ignore)]
    //    public LanguageEnum LanguageID { get; set; }

    //    [JsonProperty(PropertyName = "num_responses", NullValueHandling = NullValueHandling.Ignore)]
    //    public int NumberResponses { get; set; }

    //    [JsonProperty(PropertyName = "question_count", NullValueHandling = NullValueHandling.Ignore)]
    //    public int QuestionCount { get; set; }

    //    [JsonProperty(PropertyName = "nickname", NullValueHandling = NullValueHandling.Ignore)]
    //    public string NickName { get; set; }

    //    [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
    //    public TitleInfo Title { get; set; }

    //    [JsonProperty(PropertyName = "pages", NullValueHandling = NullValueHandling.Ignore)]
    //    public PageInfo[] PageList { get; set; }
    //}

}
