using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{

    public class AnswerInfo
    {
        [JsonProperty(PropertyName = "answer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AnswerID { get; set; }

        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public int Position { get; set; }

        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public AnswerTypeEnum AnswerType { get; set; }

        [JsonProperty(PropertyName = "visible", NullValueHandling = NullValueHandling.Ignore)]
        public bool Visible { get; set; }

        [JsonProperty(PropertyName = "weight", NullValueHandling = NullValueHandling.Ignore)]
        public int Weight { get; set; }

        [JsonProperty(PropertyName = "apply_all_rows", NullValueHandling = NullValueHandling.Ignore)]
        public bool ApplyAllRow { get; set; }

        [JsonProperty(PropertyName = "is_answer", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAnswer { get; set; }

        [JsonProperty(PropertyName = "row", NullValueHandling = NullValueHandling.Ignore)]
        public string Row { get; set; }

        [JsonProperty(PropertyName = "col", NullValueHandling = NullValueHandling.Ignore)]
        public string Column { get; set; }

        [JsonProperty(PropertyName = "col_choice", NullValueHandling = NullValueHandling.Ignore)]
        public string ColumnChoice { get; set; }

        [JsonProperty(PropertyName = "items", NullValueHandling = NullValueHandling.Ignore)]
        public AnswerItemInfo[] ItemList { get; set; }
    }

    public class AnswerItemInfo 
    {
        [JsonProperty(PropertyName = "answer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AnswerID { get; set; }

        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public int Position { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public AnswerTypeEnum AnswerType { get; set; }

        [JsonProperty(PropertyName = "text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }

}
