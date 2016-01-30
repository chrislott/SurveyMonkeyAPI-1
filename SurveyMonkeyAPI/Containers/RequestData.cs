using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SurveyMonkey.Containers
{
    public class BasicRequestData 
    {
        [JsonProperty(PropertyName = "collector_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CollectorID { get; set; }

        [JsonProperty(PropertyName = "fields", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Fields { get; set; } //{ get { return fieldData; } set { fieldData = value; } }

        [JsonProperty(PropertyName = "page", NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }

        [JsonProperty(PropertyName = "page_size", NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        [JsonProperty(PropertyName = "respondent_ids", NullValueHandling = NullValueHandling.Ignore)]
        public string[] RespondentIDList { get; set; }

        [JsonProperty(PropertyName = "survey_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SurveyID { get; set; }

        [JsonProperty(PropertyName = "from_survey_id", NullValueHandling = NullValueHandling.Ignore)]
        public string FromSurveyID { get; set; }

        [JsonProperty(PropertyName = "survey_title", NullValueHandling = NullValueHandling.Ignore)]
        public string SurveyTitle { get; set; }

        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "template_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TemplateID { get; set; }

        public void SetFields(object data)
        {
            // TODO: Build this out...
        }
    }

    public class KeyRequestData
    {
        public Dictionary<string, string> myProps { get; set; }
        public void AddProp(string key, string value)
        {
            if (myProps == null) myProps = new Dictionary<string, string>();
            myProps.Add(key, value);
        }

        public string GetJSonRequest()
        {
            return JsonConvert.SerializeObject(myProps);
        }
    }

    public class CreateCollectorRequest
    {
        public CreateCollectorRequest()
        {
            Collector = new CollectorInternal();
        }
        [JsonProperty(PropertyName = "survey_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SurveyID { get; set; }

        [JsonProperty(PropertyName = "collector", NullValueHandling = NullValueHandling.Ignore)]
        public CollectorInternal Collector { get; set; }

        public class CollectorInternal
        {
            [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
            public CollectorTypeEnum Type { get; set; }

            [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "thank_you_message", NullValueHandling = NullValueHandling.Ignore)]
            public string ThankYouMsg { get; set; }

            [JsonProperty(PropertyName = "redirect_url", NullValueHandling = NullValueHandling.Ignore)]
            public string RedirectURL { get; set; }
        }
    }

    public class CreateFlowRequest
    {
        public CreateFlowRequest()
        {
            Survey = new CreateSurveyInternal();
            Collector = new CreateCollectorInternal();
            EmailMessage = new EmailMessageInfo();
        }
        [JsonProperty(PropertyName = "survey", NullValueHandling = NullValueHandling.Ignore)]
        public CreateSurveyInternal Survey { get; set; }

        [JsonProperty(PropertyName = "collector", NullValueHandling = NullValueHandling.Ignore)]
        public CreateCollectorInternal Collector { get; set; }

        [JsonProperty(PropertyName = "email_message", NullValueHandling = NullValueHandling.Ignore)]
        public EmailMessageInfo EmailMessage { get; set; }

        public class CreateSurveyInternal
        {
            private string templateID = null;
            private string surveyID = null;

            [JsonProperty(PropertyName = "template_id", NullValueHandling = NullValueHandling.Ignore)]
            public string TemplateID { get { return templateID; } set { surveyID = null; templateID = value; } }

            [JsonProperty(PropertyName = "from_survey_id", NullValueHandling = NullValueHandling.Ignore)]
            public string SurveyID { get { return surveyID; } set { templateID = null; surveyID = value; } }

            [JsonProperty(PropertyName = "language_id", NullValueHandling = NullValueHandling.Ignore)]
            public LanguageEnum Language { get; set; }

            [JsonProperty(PropertyName = "survey_title", NullValueHandling = NullValueHandling.Ignore)]
            public string Title { get; set; }
        }

        public class CreateCollectorInternal
        {
            [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
            public CollectorTypeEnum Type { get; set; }

            [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "thank_you_message", NullValueHandling = NullValueHandling.Ignore)]
            public string ThankYouMsg { get; set; }

            [JsonProperty(PropertyName = "redirect_url", NullValueHandling = NullValueHandling.Ignore)]
            public string RedirectURL { get; set; }

            [JsonProperty(PropertyName = "recipients", NullValueHandling = NullValueHandling.Ignore)]
            public RecipientInfo[] RecipientList { get; set; }

            [JsonProperty(PropertyName = "send", NullValueHandling = NullValueHandling.Ignore)]
            public bool SendEmailNotification { get; set; }

        }
    }

    public class SendFlowRequest
    {
        public SendFlowRequest()
        {
            Collector = new SendCollectorInternal();
            EmailMessage = new EmailMessageInfo();
        }
        [JsonProperty(PropertyName = "survey_id", NullValueHandling = NullValueHandling.Ignore)]
        public string SurveyID { get; set ; }

        [JsonProperty(PropertyName = "collector", NullValueHandling = NullValueHandling.Ignore)]
        public SendCollectorInternal Collector { get; set; }

        [JsonProperty(PropertyName = "email_message", NullValueHandling = NullValueHandling.Ignore)]
        public EmailMessageInfo EmailMessage { get; set; }

        public class SendCollectorInternal
        {
            [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
            public CollectorTypeEnum Type { get; set; }

            [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "thank_you_message", NullValueHandling = NullValueHandling.Ignore)]
            public string ThankYouMsg { get; set; }

            [JsonProperty(PropertyName = "redirect_url", NullValueHandling = NullValueHandling.Ignore)]
            public string RedirectURL { get; set; }

            [JsonProperty(PropertyName = "recipients", NullValueHandling = NullValueHandling.Ignore)]
            public RecipientInfo[] RecipientList { get; set; }

            [JsonProperty(PropertyName = "send", NullValueHandling = NullValueHandling.Ignore)]
            public bool SendEmailNotification { get; set; }

        }
    }


}
