using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SurveyMonkey.Containers;
using SurveyMonkey.Responses;
namespace SurveyMonkey
{
    /// <summary>
    /// Note most of the method documentation comes directly from SurveyMonkey.  However, some notes and
    /// other things have been added for clarification.
    /// Docs can be located at https://developer.surveymonkey.com/docs/overview/getting-started/
    /// </summary>
    public class SurveyMonkeyRequest
    {
        private const string CREATE_FLOW = @"/batch/create_flow";
        private const string GET_SURVEY_DETAILS = @"/surveys/get_survey_details";
        private const string GET_USER_DETAILS = @"/user/get_user_details";
        private const string GET_SURVEY_LIST = @"/surveys/get_survey_list";
        private const string SEND_FLOW = @"/batch/send_flow";
        private const string GET_COLLECTOR_LIST = @"/surveys/get_collector_list";
        private const string CREATE_RECIPIENTS = @"/collectors/create_recipients";
        private const string CREATE_SURVEY = @"/surveys/create_survey";
        private const string CREATE_EMAIL_MESSAGE = @"/emails/create_email_message";
        private const string GET_TEMPLATE_LIST = @"/templates/get_template_list";
        private const string CREATE_COLLECTOR = @"/collectors/create_collector";
        private const string GET_RESPONDENT_LIST = @"/surveys/get_respondent_list";
        private const string GET_RESPONSES = @"/surveys/get_responses";
        private const string GET_RESPONSE_COUNTS = @"/surveys/get_response_counts";
        
        public string JsonResponse { get; set; }
        public string JsonRequest { get; set; }
        public DateTime LastRequestTime { get; set; }
        public int NumberRequestsIssued { get; set; }
        public int QuotaAllotted { get; private set; }
        public int QuotaUsed { get; private set; }
        public string BaseURL { get; set; }
        public string APIKey { get; set; }
        public string AuthSecret { get; set; }
        public string Token { get; set; }
        public int RateLimitDelayMS { get; set; }

        public SurveyMonkeyRequest()
        {
            NumberRequestsIssued = 0;
            LastRequestTime = DateTime.Now.AddSeconds(- 1);

            BaseURL = ConfigurationManager.AppSettings["SurveyMonkeyBaseURL"].ToString();
            APIKey = ConfigurationManager.AppSettings["APIKey"].ToString();
            AuthSecret = ConfigurationManager.AppSettings["AuthSecret"].ToString();
            Token = ConfigurationManager.AppSettings["Token"].ToString();
            string RLDMS = ConfigurationManager.AppSettings["RateLimitDelayMS"].ToString();
            try
            {
                int RLD = int.Parse(RLDMS);
                RateLimitDelayMS = RLD;
            }
            catch
            {
                RateLimitDelayMS = 500; // set default to 2 times per second.
            }
        }

        /// <summary>
        /// Create a survey based on template or existing survey.
        /// Notes
        ///     You cannot specify both template\_id and from\_survey\_id
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/create_survey?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/create_survey?api_key=your_api_key --data-binary '{"template_id": "568", "survey_title": "Ice and Fire Event"}'
        /// </summary>
        public CreateSurveyResponse CreateSurvey (BasicRequestData requestData)
        {
            CreateSurveyResponse surveyList;
            BasicRequestData thisRequest = new BasicRequestData();

            // This request expects a from_survey_id not the standard survey_id
            if (requestData.SurveyID != null)
            {
                requestData.FromSurveyID = requestData.SurveyID;
                requestData.SurveyID = null;
            }

            // This request can only take one of FromSurveyID or TemplateID not both
            if ((requestData.FromSurveyID != null) && (requestData.TemplateID != null))
            {
                surveyList = new CreateSurveyResponse();
                surveyList.Status = -2;
                surveyList.ErrorMessage = "Specify either from_survey_id or template_id, not both.";
            }
            else if (requestData.SurveyTitle == null)
            {
                surveyList = new CreateSurveyResponse();
                surveyList.Status = -3;
                surveyList.ErrorMessage = "Survey Title (survey_title) is required for this call.";
            }
            else if ((requestData.FromSurveyID == null) && (requestData.TemplateID == null))
            {
                surveyList = new CreateSurveyResponse();
                surveyList.Status = -4;
                surveyList.ErrorMessage = "One of from_survey_id or template_id must be specified for this call.";
            }
            else
            {
                thisRequest.FromSurveyID = requestData.FromSurveyID;
                thisRequest.TemplateID = requestData.TemplateID;
                thisRequest.SurveyTitle = requestData.SurveyTitle;
                JsonResponse = MakeApiRequest(CREATE_SURVEY, requestData);
                surveyList = JsonConvert.DeserializeObject<CreateSurveyResponse>(JsonResponse);
            }

            return surveyList;
        }

        /// <summary>
        /// Create a survey, email collector, and email message based on a template or existing survey. ###Notes * You cannot specify both template_id and from survey_id * Maximum number of recipients supported is 10000
        /// Endpoint : https://api.surveymonkey.net/v2/batch/create_flow?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/batch/create_flow?api_key=your_api_key --data-binary 
        /// </summary>
        public CreateFlowResponse CreateFlow(CreateFlowRequest requestData)
        {
            CreateFlowResponse flowResponse;
            
            JsonResponse = MakeApiRequest(CREATE_FLOW, requestData);
            flowResponse = JsonConvert.DeserializeObject<CreateFlowResponse>(JsonResponse);

            return flowResponse;
        }

        /// <summary>
        /// Create an email collector and email message attaching them to an existing survey.
        /// Notes
        ///     •Maximum number of recipients supported is 1000
        ///     •Basic users will have requests fail if they have more than 3 collectors, 
        ///      response will have the upgrade_info dictionary
        /// Endpoint : https://api.surveymonkey.net/v2/batch/send_flow?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/batch/send_flow?api_key=your_api_key --data-binary '{"survey_id": "100487745", "collector": {"type": "email", "name" : "email invite", "recipients": [{"email": "xyzstannis@surveymonkey.com", "first_name": "Stannis", "last_name": "Baratheon", "custom_id": "94301"}, {"email": "xyzjoffrey@surveymonkey.com", "first_name": "Joffrey", "last_name": "Baratheon", "custom_id": "94401"}, {"email": "renly@surveymonkey"}]}, "email_message" : { "subject" : "Ice and Fire event" , "reply_email" : "xyzcersei@surveymonkey.com", "body_text" : "We are conducting a survey, and your response would be appreciated. Here is a link to the survey: [SurveyLink] This link is uniquely tied to this survey and your email address. Please do not forward this message. Thanks for your participation! Please note: If you do not wish to receive further emails from us, please click the link below, and you will be automatically removed from our mailing list. [RemoveLink]"}}'
        /// </summary>
        public SendFlowResponse SendFlow(SendFlowRequest requestData)
        {
            SendFlowResponse flowResponse;

            JsonResponse = MakeApiRequest(SEND_FLOW, requestData);
            flowResponse = JsonConvert.DeserializeObject<SendFlowResponse>(JsonResponse);

            return flowResponse;
        }

        /// <summary>
        /// Retrieve a given survey's metadata.
        /// Notes
        ///     •Surveys with over 200 survey pages will not be returned
        ///     •Surveys with over 1000 questions will not be returned
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_survey_details?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_survey_details/?api_key=your_api_key --data-binary '{"survey_id":"100399456"}'
        /// </summary>
        public CreateCollectorResponse CreateCollector(CreateCollectorRequest requestData)
        {
            CreateCollectorResponse collectorResponse;
            CreateCollectorRequest thisRequest = new CreateCollectorRequest();

            // This request requires a survey id.
            if (requestData.SurveyID == null)
            {
                collectorResponse = new CreateCollectorResponse();
                collectorResponse.Status = -4;
                collectorResponse.ErrorMessage = "Survey ID must be specified.";
            }
            else
            {
                requestData.Collector.Type = CollectorTypeEnum.WebLink;  // currently API only allows weblink.
                JsonResponse = MakeApiRequest(CREATE_COLLECTOR, requestData);
                collectorResponse = JsonConvert.DeserializeObject<CreateCollectorResponse>(JsonResponse);
            }

            return collectorResponse;
        }

        /// <summary>
        /// Returns basic information about the logged-in user
        /// Endpoint : https://api.surveymonkey.net/v2/user/get_user_details?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/user/get_user_details/?api_key=your_api_key
        /// </summary>
        public GetUserDetailsResponse GetUserDetails(BasicRequestData requestData)
        {
            JsonResponse = MakeApiRequest(GET_USER_DETAILS, requestData);
            GetUserDetailsResponse surveyList = JsonConvert.DeserializeObject<GetUserDetailsResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        /// Retrieves a paged list of surveys in a user's account.
        /// Notes
        ///     •DateStrings must be in the format YYYY-MM-DD HH:MM:SS.All DateStrings are implicitly in UTC.
        ///     •All start dates are greater than or equal to the date passed in
        ///     •All end dates are strictly less than the date passed in
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_survey_list?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_survey_list/?api_key=your_api_key --data-binary '{"fields":["title","analysis_url","date_created","date_modified"], "start_date":"2013-02-02 00:00:00", "end_date":"2013-04-12 22:43:01", "order_asc":false, "title":"test3"}'
        /// </summary>
        public GetSurveyDetailsResponse GetSurveyDetails(BasicRequestData requestData)
        {
            JsonResponse = MakeApiRequest(GET_SURVEY_DETAILS, requestData);
            GetSurveyDetailsResponse surveyList = JsonConvert.DeserializeObject<GetSurveyDetailsResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        /// Returns how many respondents have started and/or completed the survey for the given collector
        /// Notes
        ///     • CollectorID is required. CollectorID is a string and part of BasicRequestData object.
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_response_counts?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_response_counts/?api_key=your_api_key --data-binary '{"collector_id": "23907195"}'
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        public GetResponseCountsResponse GetResponseCounts(BasicRequestData requestData)
        {
            JsonResponse = MakeApiRequest(GET_RESPONSE_COUNTS, requestData);
            GetResponseCountsResponse surveyList = JsonConvert.DeserializeObject<GetResponseCountsResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        /// Retrieves a paged list of templates with all template items filled out provided by Survey Monkey.
        /// Notes
        ///     If templates are returned that the user cannot access, the `upgrade_info` dictionary will be returned
        /// Endpoint : https://api.surveymonkey.net/v2/templates/get_template_list?api_key=your_api_key
        /// </summary>
        public GetTemplateListResponse GetTemplateListFull(BasicRequestData requestData)
        {
            string[] fData = { "title", "short_description", "preview_url", "date_created", "date_modified", "language_id", "question_count"
                            , "long_description", "is_available_to_current_user", "is_featured", "is_certified", "page_count"
                            , "category_id", "category_name", "category_description"};
            requestData.Fields = fData;

            return GetTemplateList(requestData);
        }

        /// <summary>
        /// Retrieves a paged list of templates provided by Survey Monkey.
        /// Notes
        ///     If templates are returned that the user cannot access, the `upgrade_info` dictionary will be returned
        /// Endpoint : https://api.surveymonkey.net/v2/templates/get_template_list?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/templates/get_template_list?api_key=your_api_key --data-binary '{"page": 1, "page_size": 10, "language_id": 1, "category_id": "131", "fields" : ["title"]}'
        /// </summary>
        public GetTemplateListResponse GetTemplateList(BasicRequestData requestData)
        {
            JsonResponse = MakeApiRequest(GET_TEMPLATE_LIST, requestData);
            GetTemplateListResponse surveyList = JsonConvert.DeserializeObject<GetTemplateListResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        /// Retrieves a paged list of surveys in a user's account with all template items filled.
        /// Notes
        ///     •DateStrings must be in the format YYYY-MM-DD HH:MM:SS.All DateStrings are implicitly in UTC.
        ///     •All start dates are greater than or equal to the date passed in
        ///     •All end dates are strictly less than the date passed in
        /// Endpoints : https://api.surveymonkey.net/v2/surveys/get_survey_list?api_key=your_api_key
        public GetSurveyListResponse GetSurveyListFull(BasicRequestData requestData)
        {
            string[] fData = { "title", "analysis_url", "preview_url", "date_created", "date_modified", "language_id", "question_count", "num_responses" };
            requestData.Fields = fData;

            return GetSurveyList(requestData);
        }

        /// <summary>
        /// Retrieves a paged list of surveys in a user's account.
        /// Notes
        ///     •DateStrings must be in the format YYYY-MM-DD HH:MM:SS.All DateStrings are implicitly in UTC.
        ///     •All start dates are greater than or equal to the date passed in
        ///     •All end dates are strictly less than the date passed in
        /// Endpoints : https://api.surveymonkey.net/v2/surveys/get_survey_list?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_survey_list/?api_key=your_api_key --data-binary '{"fields":["title","analysis_url","date_created","date_modified"], "start_date":"2013-02-02 00:00:00", "end_date":"2013-04-12 22:43:01", "order_asc":false, "title":"test3"}'
        /// </summary>
        public GetSurveyListResponse GetSurveyList(BasicRequestData requestData)
        {
            if (requestData.SurveyTitle != null)
            {
                requestData.Title = requestData.SurveyTitle;
                requestData.SurveyTitle = null;
            }
            JsonResponse = MakeApiRequest(GET_SURVEY_LIST, requestData);
            GetSurveyListResponse surveyList = JsonConvert.DeserializeObject<GetSurveyListResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        /// Retrieves a paged list of collectors for a survey in a user's account with all template items filled
        /// Notes
        ///     DateStrings must be in the format YYYY-MM-DD HH:MM:SS.All DateStrings are implicitly in UTC.
        ///     All start dates are greater than or equal to the date passed in
        ///     All end dates are strictly less than the date passed in
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_collector_list?api_key=your_api_key
        /// </summary>
        public GetCollectorListResponse GetCollectorListFull(BasicRequestData requestData)
        {
            // url, open, type, name, date_created, date_modified
            string[] fData = { "url", "open", "type", "name", "date_created", "date_modified"};
            requestData.Fields = fData;

            return GetCollectorList(requestData);
        }

        /// <summary>
        /// Retrieves a paged list of collectors for a survey in a user's account
        /// Notes
        ///     DateStrings must be in the format YYYY-MM-DD HH:MM:SS.All DateStrings are implicitly in UTC.
        ///     All start dates are greater than or equal to the date passed in
        ///     All end dates are strictly less than the date passed in
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_collector_list?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_collector_list/?api_key=your_api_key --data-binary '{"survey_id": "100399456", "fields":["collector_id", "url", "open", "type", "name", "date_created", "date_modified"], "start_date":"2013-02-05 00:00:00", "end_date":"2013-04-16 22:47:00", "order_asc":true, "page_size":1, "page":2}'
        /// </summary>
        public GetCollectorListResponse GetCollectorList(BasicRequestData requestData)
        {
            JsonResponse = MakeApiRequest(GET_COLLECTOR_LIST, requestData);
            GetCollectorListResponse surveyList = JsonConvert.DeserializeObject<GetCollectorListResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        /// Retrieves a paged list of respondents for a given survey and optionally collector with all template items filled
        /// Notes
        ///     Surveys with over 500,000 respondents will not be returned
        ///     DateStrings must be in the format YYYY-MM-DD HH:MM:SS.All DateStrings are implicitly in UTC.
        ///     All start dates are greater than or equal to the date passed in
        ///     All end dates are strictly less than date passed in
        ///     Basic users will only have the first 100 responses returned and will have the upgrade\_info dictionary
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_respondent_list?api_key=your_api_key
        /// </summary>
        public GetRespondentListResponse GetRespondentListFull(BasicRequestData requestData)
        {
            // url, open, type, name, date_created, date_modified
            string[] fData = { "date_start", "date_modified", "collector_id", "collection_mode", "custom_id", "email"
                                , "first_name", "last_name", "ip_address", "status", "analysis_url", "recipient_id" };
            requestData.Fields = fData;

            return GetRespondentList(requestData);
        }

        /// <summary>
        /// Retrieves a paged list of respondents for a given survey and optionally collector
        /// Notes
        ///     Surveys with over 500,000 respondents will not be returned
        ///     DateStrings must be in the format YYYY-MM-DD HH:MM:SS.All DateStrings are implicitly in UTC.
        ///     All start dates are greater than or equal to the date passed in
        ///     All end dates are strictly less than date passed in
        ///     Basic users will only have the first 100 responses returned and will have the upgrade\_info dictionary
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_respondent_list?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_respondent_list/?api_key=your_api_key --data-binary '{"survey_id": "100399456", "fields":["collector_id", "url", "open", "type", "name", "date_created", "date_modified"], "start_date":"2013-02-05 00:00:00", "end_date":"2013-04-16 22:47:00", "order_asc":true, "page_size":1, "page":2}'
        /// </summary>
        public GetRespondentListResponse GetRespondentList(BasicRequestData requestData)
        {
            JsonResponse = MakeApiRequest(GET_RESPONDENT_LIST, requestData);
            GetRespondentListResponse surveyList = JsonConvert.DeserializeObject<GetRespondentListResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        /// Takes a list of respondent ids and returns the responses that correlate to them.To be used with 'get_survey_details'
        /// Notes
        ///     Surveys with over 500,000 reponses are not available via the API currently
        ///     Text responses returned are truncated after 32,768 characters
        ///     Max number of respondents per call is 100
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_responses?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_responses/?api_key=your_api_key --data-binary '{"survey_id":"103994756", "respondent_ids": ["2503019027", "2500039028", "2500039029", "2503019064"]}'
        /// </summary>
        public GetResponsesResponse GetResponses(BasicRequestData requestData)
        {
            JsonResponse = MakeApiRequest(GET_RESPONSES, requestData);
            GetResponsesResponse surveyList = JsonConvert.DeserializeObject<GetResponsesResponse>(JsonResponse);

            return surveyList;
        }

        /// <summary>
        ///  Generic API request.  When only Basic Request Data is required.
        /// </summary>
        /// <returns></returns>
        private string MakeApiRequest(string endPoint, BasicRequestData data)
        {
            string url = BaseURL + endPoint;
            var serializedParameters = JsonConvert.SerializeObject(data);

            return MakeApiRequest(url, serializedParameters);
        }

        /// <summary>
        /// Specific for when sending request data for creating a new survey to email out to a list of recipients
        /// </summary>
        private string MakeApiRequest(string endPoint, CreateFlowRequest data)
        {
            string url = BaseURL + endPoint;
            var serializedParameters = JsonConvert.SerializeObject(data);

            return MakeApiRequest(url, serializedParameters);
        }

        /// <summary>
        /// Specific for when sending request data for sending out an existing survey to a list of recipients
        /// </summary>
        private string MakeApiRequest(string endPoint, SendFlowRequest data)
        {
            string url = BaseURL + endPoint;
            var serializedParameters = JsonConvert.SerializeObject(data);

            return MakeApiRequest(url, serializedParameters);
        }

        /// <summary>
        /// Specific for when sending request data for creating a new collector
        /// </summary>
        private string MakeApiRequest(string endPoint, CreateCollectorRequest data)
        {

            string url = BaseURL + endPoint;
            string serializedParameters = JsonConvert.SerializeObject(data);

            return MakeApiRequest(url, serializedParameters);
        }

        /// <summary>
        /// Accesses the API endpoint provided by Survey Monkey and returns the response data
        /// </summary>
        /// <returns></returns>
        private string MakeApiRequest(string url, string serializedParameters)
        {
            string result;

            RateLimit();

            JsonRequest = serializedParameters;
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Encoding = Encoding.UTF8;
                    webClient.Headers.Add("Content-Type", "application/json");
                    webClient.Headers.Add("Authorization", "Bearer " + Token);
                    webClient.QueryString.Add("api_key", APIKey);
                    result = webClient.UploadString(url, "POST", serializedParameters);
                    UpdateQuotaInformation(webClient.ResponseHeaders);
                }

                LastRequestTime = DateTime.Now;
                NumberRequestsIssued++;
            }
            catch (Exception e)
            {
                result = string.Format(@"{{ ""status"": -1, ""errmsg"" : ""{0}"" }}", e.Message);
            }

            return result;
        }

        /// <summary>
        /// Prevents more than one call from being made to the web client within the RateLimitDelayMS time span
        /// </summary>
        private void RateLimit()
        {
            TimeSpan timeSpan = DateTime.Now - LastRequestTime;
            int elapsedTime = (int)timeSpan.TotalMilliseconds;
            int remainingTime = RateLimitDelayMS - elapsedTime;
            if ((LastRequestTime != DateTime.MinValue) && (remainingTime > 0))
            {
                Thread.Sleep(remainingTime);
            }
            LastRequestTime = DateTime.Now; //Also setting here as otherwise if a WebException is thrown while making the request it wouldn't get set at all
        }

        /// <summary>
        /// Updates quota information from the request, showing the maximum number of allowed requests and the actual number used
        /// </summary>
        private void UpdateQuotaInformation(WebHeaderCollection headers)
        {
            try
            {
                QuotaAllotted = Int32.Parse(headers["X-Plan-Quota-Allotted"]);
                QuotaUsed = Int32.Parse(headers["X-Plan-Quota-Current"]);
            }
            catch (Exception)
            {
                //Just swallow anything. The information's not critical and I'm not sure the header's guaranteed to exist.
                //If there's an actual problem it'll be more helpful to throw in ParseApiResponse()
            }
        }
    }
}
