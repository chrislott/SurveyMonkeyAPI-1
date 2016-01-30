using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SurveyMonkey.Containers
{
    public class BaseContainer
    {
        [JsonProperty(PropertyName = "date_created", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DateCreated { get; set; }

        [JsonProperty(PropertyName = "date_modified", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DateModified { get; set; }

        [JsonProperty(PropertyName = "survey_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SurveyID { get; set; }

        //[JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        //public int Status { get; set; }
    }

    public class CustomVariableInfo
    {
        public int VariableID { get; set; }

        [JsonProperty(PropertyName = "variable_label", NullValueHandling = NullValueHandling.Ignore)]
        public string VariableLable { get; set; }

        [JsonProperty(PropertyName = "question_id", NullValueHandling = NullValueHandling.Ignore)]
        public string QuestionID { get; set; }
    }


    public class TitleInfo
    {
        [JsonProperty(PropertyName = "enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool Enabled { get; set; }

        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleText { get; set; }
    }

    public class UpgradeInfo
    {
        [JsonProperty(PropertyName = "upgrade_url", NullValueHandling = NullValueHandling.Ignore)]
        public string UpgradeURL { get; set; }

        [JsonProperty(PropertyName = "restrictions", NullValueHandling = NullValueHandling.Ignore)]
        public RestrictionInfo[] RestrictionList { get; set; }
    }


    public class RestrictionInfo
    {
        [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }
    }

}
