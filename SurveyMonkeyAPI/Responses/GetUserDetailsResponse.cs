using Newtonsoft.Json;
using SurveyMonkey.Containers;

namespace SurveyMonkey.Responses
{
    /// <summary>
    /// Handles response data for https://api.surveymonkey.net/v2/user/get_user_details endpoint provided by SurveyMonkey
    /// </summary>
    public class GetUserDetailsResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "data", Required = Required.Always)]
        public GetUserDetailsResult UserDetailsResult { get; set; }
    }

    public class GetUserDetailsResult
    {
        [JsonProperty(PropertyName = "user_details", Required = Required.Always)]
        public UserDetailInfo UserDetails { get; set; }

        [JsonProperty(PropertyName = "enterprise_details", NullValueHandling = NullValueHandling.Ignore)]
        public EnterpriseDetailsInfo EnterpriseDetails { get; set; }
    }

}
