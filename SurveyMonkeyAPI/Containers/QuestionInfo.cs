using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    public class QuestionInfo
    {
        [JsonProperty(PropertyName = "question_id", NullValueHandling = NullValueHandling.Ignore)]
        public string QuestionID { get; set; }

        [JsonProperty(PropertyName = "heading", NullValueHandling = NullValueHandling.Ignore)]
        public string Heading { get; set; }

        [JsonProperty(PropertyName = "position", NullValueHandling = NullValueHandling.Ignore)]
        public int Position { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
        public QuestionTypeInfo QuestionType { get; set; }

        [JsonProperty(PropertyName = "answers", NullValueHandling = NullValueHandling.Ignore)]
        public AnswerInfo[] QuestionAnswerList { get; set; }
    }

    public class QuestionTypeInfo
    {
        [JsonProperty(PropertyName = "family", NullValueHandling = NullValueHandling.Ignore)]
        public QuestionFamilyEnum Family { get; set; }

        [JsonProperty(PropertyName = "subtype", NullValueHandling = NullValueHandling.Ignore)]
        public QuestionSubtypeEnum Subtype { get; set; }
    }
}
