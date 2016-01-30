using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    public class SurveyBaseInfo : BaseContainer
    {

        [JsonProperty(PropertyName = "question_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? QuestionCount { get; set; }

        [JsonProperty(PropertyName = "num_responses", NullValueHandling = NullValueHandling.Ignore)]
        public int? NumberResponses { get; set; }

        [JsonProperty(PropertyName = "analysis_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AnalysisURL { get; set; }

        [JsonProperty(PropertyName = "preview_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviewURL { get; set; }

        [JsonProperty(PropertyName = "template_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateID { get; set; }

        [JsonProperty(PropertyName = "from_survey_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FromSurveyID { get; set; }


        [JsonProperty(PropertyName = "language_id", NullValueHandling = NullValueHandling.Ignore)]
        public LanguageEnum? LanguageID { get; set; }

        [JsonProperty(PropertyName = "custom_variable_count", NullValueHandling = NullValueHandling.Ignore)]
        public int CustomVariableCount { get; set; }

        [JsonProperty(PropertyName = "custom_variables", NullValueHandling = NullValueHandling.Ignore)]
        public CustomVariableInfo[] CustomVariableList { get; set; }

        [JsonProperty(PropertyName = "nickname", NullValueHandling = NullValueHandling.Ignore)]
        public string NickName { get; set; }

        [JsonProperty(PropertyName = "pages", NullValueHandling = NullValueHandling.Ignore)]
        public PageInfo[] PageList { get; set; }

    }

    public class SurveyTInfo : SurveyBaseInfo
    {
        // get_survey_details, 
        // return title as a structure.
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public TitleInfo TitleDetail { get; set; }
    }

    public class SurveyInfo : SurveyBaseInfo
    {
        // Survey Title is necessary for request package.
        [JsonProperty(PropertyName = "survey_title", NullValueHandling = NullValueHandling.Ignore)]
        public string SurveyTitle { get; set; }

        // create_flow, get_survey_list, send_flow, create_survey
        // return title as a string.
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }
}
