using Newtonsoft.Json;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Base response for Survey Monkey API
    /// </summary>
    public class BaseResponse
    {
        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "errmsg", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    }
}
