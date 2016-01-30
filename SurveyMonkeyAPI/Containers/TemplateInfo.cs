using Newtonsoft.Json;

namespace SurveyMonkey.Containers
{
    public class TemplateInfo : BaseContainer
    {
        [JsonProperty(PropertyName = "category_description", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryDescription { get; set; }

        [JsonProperty(PropertyName = "category_id", NullValueHandling = NullValueHandling.Ignore)]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "category_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryName { get; set; }

        [JsonProperty(PropertyName = "long_description", NullValueHandling = NullValueHandling.Ignore)]
        public string LongDescription { get; set; }

        [JsonProperty(PropertyName = "short_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortDescription { get; set; }

        [JsonProperty(PropertyName = "template_id", NullValueHandling = NullValueHandling.Ignore)]
        public int TemplateID { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "page_count", NullValueHandling = NullValueHandling.Ignore)]
        public int PageCount { get; set; }

        [JsonProperty(PropertyName = "language_id", NullValueHandling = NullValueHandling.Ignore)]
        public LanguageEnum Language { get; set; }

        [JsonProperty(PropertyName = "is_available_to_current_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAvailableCurrentUser { get; set; }

        [JsonProperty(PropertyName = "is_featured", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsFeatured { get; set; }

        [JsonProperty(PropertyName = "is_certified", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCertified { get; set; }

        [JsonProperty(PropertyName = "question_count", NullValueHandling = NullValueHandling.Ignore)]
        public int QuestionCount { get; set; }

        [JsonProperty(PropertyName = "preview_url", NullValueHandling = NullValueHandling.Ignore)]
        public string PreviewURL { get; set; }
    }
}
