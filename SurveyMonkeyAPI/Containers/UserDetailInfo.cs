using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SurveyMonkey.Containers
{
    public class UserDetailInfo
    {
        [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "account_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountType { get; set; }

        [JsonProperty(PropertyName = "is_paid_account", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPaidAccount { get; set; }

        [JsonProperty(PropertyName = "user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string UserID { get; set; }

        [JsonProperty(PropertyName = "is_enterprise_user", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEnterpriseUser { get; set; }
    }
    
    public class EnterpriseDetailsInfo
    {
        [JsonProperty(PropertyName = "group_id", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupID { get; set; }

        [JsonProperty(PropertyName = "group_name", NullValueHandling = NullValueHandling.Ignore)]
        public string GroupName { get; set; }

        [JsonProperty(PropertyName = "total_seats_invoiced", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalSeatsInvoiced { get; set; }

        [JsonProperty(PropertyName = "total_seats_active", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalSeatsActive { get; set; }

        [JsonProperty(PropertyName = "salesforce_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSalesforceEnabled { get; set; }

        [JsonProperty(PropertyName = "salesforce_pro_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSalesforceProEnabled { get; set; }

    }
}
