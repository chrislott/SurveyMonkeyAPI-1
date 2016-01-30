using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    public class PageInfo
    {
        [JsonProperty(PropertyName = "page_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PageID { get; set; }

        [JsonProperty(PropertyName = "heading", NullValueHandling = NullValueHandling.Ignore)]
        public string Heading { get; set; }

        [JsonProperty(PropertyName = "sub_heading", NullValueHandling = NullValueHandling.Ignore)]
        public string SubHeading { get; set; }

        [JsonProperty(PropertyName = "questions", NullValueHandling = NullValueHandling.Ignore)]
        public QuestionInfo[] QuestionList { get; set; }

    }

}
