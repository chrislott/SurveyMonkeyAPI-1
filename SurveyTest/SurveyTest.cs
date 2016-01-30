using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SurveyMonkey;
using SurveyMonkey.Responses;
using SurveyMonkey.Containers;
using SurveyMonkey.Views;
using System.Configuration;

namespace SurveyTest
{
    public partial class SurveyTest : Form
    {
        private CreateFlowForm cff;
        private SendFlowForm sff;
        private SurveyMonkeyRequest SurveyRequest;
        private frmViewJson viewJsonResponse = null;
        private frmViewJson viewJsonRequest = null;
        
        public SurveyTest()
        {
            InitializeComponent();
        
            SurveyRequest = new SurveyMonkeyRequest();

            btnCreateFlow.Click += BtnCreateFlow_Click; // done
            btnGetSurveyDetails.Click += BtnGetSurveyDetails_Click; // done
            btnGetUserDetails.Click += BtnGetUserDetails_Click; // done
            btnGetSurveyList.Click += BtnGetSurveyList_Click; // done
            btnSendFlow.Click += BtnSendFlow_Click; // done
            btnGetCollectorList.Click += BtnGetCollectorList_Click; // done
            btnCreateRecipients.Click += BtnCreateRecipients_Click;
            btnCreateSurvey.Click += BtnCreateSurvey_Click; // done 404
            btnCreateEmailMessage.Click += BtnCreateEmailMessage_Click;
            btnGetTemplateList.Click += BtnGetTemplateList_Click; // done
            btnCreateCollector.Click += BtnCreateCollector_Click; // done
            btnGetRespondentList.Click += BtnGetRespondentList_Click; // done
            btnGetResponses.Click += BtnGetResponses_Click; // done
            btnGetResponseCounts.Click += BtnGetResponseCounts_Click; // done
            btnGetResponseSummary.Click += BtnGetResponseSummary_Click; // done

            btnJsonResponse.Click += BtnJsonResponse_Click; // done
            btnJsonRequest.Click += BtnJsonRequest_Click; // done
        }

        private void BtnJsonRequest_Click(object sender, EventArgs e)
        {
            if (SurveyRequest != null)
            {
                if (viewJsonRequest == null) viewJsonRequest = new frmViewJson();
                viewJsonRequest.JSON = SurveyRequest.JsonRequest;
                if (viewJsonRequest.Visible == false) viewJsonRequest.Show();
            }
        }

        private void BtnJsonResponse_Click(object sender, EventArgs e)
        {
            if (SurveyRequest != null)
            {
                if (viewJsonResponse == null) viewJsonResponse = new frmViewJson();
                viewJsonResponse.JSON = SurveyRequest.JsonResponse;
                if (viewJsonResponse.Visible == false) viewJsonResponse.Show();
            }
        }

        /// <summary>
        /// Create a survey, email collector, and email message based on a template or existing survey. ###Notes * You cannot specify both template_id and from survey_id * Maximum number of recipients supported is 10000
        /// Endpoint : https://api.surveymonkey.net/v2/batch/create_flow?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/batch/create_flow?api_key=your_api_key --data-binary 
        /// </summary>
        private void BtnCreateFlow_Click(object sender, EventArgs e)
        {
            CreateFlowResponse flowDetails;
            if (cff == null)
            {
                cff = new CreateFlowForm();
            }
            //cff.Visible = true;
            DialogResult gotData = cff.ShowDialog();

            if (gotData == DialogResult.OK)
            {
                flowDetails = SurveyRequest.CreateFlow(cff.cfrData);
                
            }
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
        private void BtnGetSurveyDetails_Click(object sender, EventArgs e)
        {
            GetSurveyDetailsResponse surveyDetails;
            BasicRequestData brd = new BasicRequestData();
            SurveyQuestionView surveyView = new SurveyQuestionView();

            if (txtSurveyID.Text.Trim().Length > 0)
            {
                brd.SurveyID = txtSurveyID.Text;
            }
            else
            {
                brd.SurveyID = null;
            }

            if (brd.SurveyID == null)
            {
                MessageBox.Show("no survey id specified.  Going to get error back.");
            }

            surveyDetails = SurveyRequest.GetSurveyDetails(brd);

            lblStatus.Text = surveyDetails.Status.ToString();
            lblErrorMsg.Text = surveyDetails.ErrorMessage;

            try
            {
                if (chkSurveyAnswers.Checked)
                {
                    surveyView.LoadSurvey(surveyDetails);
                    dgvSurveyList.DataSource = surveyView.SurveyWithAnswers;
                }
                else
                {
                    List<SurveyTInfo> sdrList = new List<SurveyTInfo>();
                    sdrList.Add(surveyDetails.SurveyDetailsResult);
                    dgvSurveyList.DataSource = sdrList;
                }
            }
            catch { } // do nothing
        }

        /// <summary>
        /// Returns basic information about the logged-in user
        /// Endpoint : https://api.surveymonkey.net/v2/user/get_user_details?api_key=your_api_key
        /// Example Request
        ///     curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/user/get_user_details/?api_key=your_api_key
        /// </summary>
        private void BtnGetUserDetails_Click(object sender, EventArgs e)
        {
            GetUserDetailsResponse surveyDetails;
            BasicRequestData brd = new BasicRequestData();

            surveyDetails = SurveyRequest.GetUserDetails(brd);

            lblStatus.Text = surveyDetails.Status.ToString();
            lblErrorMsg.Text = surveyDetails.ErrorMessage;

            try
            {
                List<GetUserDetailsResult> sdrList = new List<GetUserDetailsResult>();
                sdrList.Add(surveyDetails.UserDetailsResult);
                dgvSurveyList.DataSource = sdrList;
            }
            catch { } // do nothing
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
        private void BtnGetSurveyList_Click(object sender, EventArgs e)
        {
            GetSurveyListResponse surveys = null;
            BasicRequestData brd = GetRequestFields();
            List<SurveyInfo> orderedDisplay = null;

            if (chkFull.Checked)
            {
                surveys = SurveyRequest.GetSurveyListFull(brd);
            }
            else
            {
                surveys = SurveyRequest.GetSurveyList(brd);
            }

            lblStatus.Text = surveys.Status.ToString();
            lblErrorMsg.Text = surveys.ErrorMessage;

            try
            {
                if (rbCreate.Checked)
                {
                    orderedDisplay = surveys.SurveyListResult.SurveyList.OrderBy(dd => dd.DateCreated).ToList<SurveyInfo>();
                }
                else if (rbModify.Checked)
                {
                    orderedDisplay = surveys.SurveyListResult.SurveyList.OrderBy(dd => dd.DateModified).ToList<SurveyInfo>();
                }
                else if (rbTitle.Checked)
                {
                    orderedDisplay = surveys.SurveyListResult.SurveyList.OrderBy(dd => dd.Title).ToList<SurveyInfo>();
                }
                else
                {
                    orderedDisplay = surveys.SurveyListResult.SurveyList.ToList<SurveyInfo>();
                }
                dgvSurveyList.DataSource = orderedDisplay;
            }
            catch { } // do nothing
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
        private void BtnSendFlow_Click(object sender, EventArgs e)
        {
            SendFlowResponse flowDetails;
            if (sff == null)
            {
                sff = new SendFlowForm();
            }
            //cff.Visible = true;
            DialogResult gotData = sff.ShowDialog();

            if (gotData == DialogResult.OK)
            {
                flowDetails = SurveyRequest.SendFlow(sff.sfrData);
            }
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
        private void BtnGetCollectorList_Click(object sender, EventArgs e)
        {
            GetCollectorListResponse collectors;
            BasicRequestData brd = GetRequestFields();

            if (brd.SurveyID == null)
            {
                MessageBox.Show("no survey id specified.  Going to get error back.");
            }

            if (chkFull.Checked)
            {
                collectors = SurveyRequest.GetCollectorListFull(brd);
            }
            else
            {
                collectors = SurveyRequest.GetCollectorList(brd);
            }

            lblStatus.Text = collectors.Status.ToString();
            lblErrorMsg.Text = collectors.ErrorMessage;

            try
            {
                dgvSurveyList.DataSource = collectors.CollectorListResult.CollectorList;
            }
            catch { } // do nothing
        }

        /// <summary>
        /// Adds a set of new recipients to an existing collector.
        /// Endpoint : https://api.surveymonkey.net/v2/collectors/create_recipients?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/collectors/create_recipients?api_key=your_api_key --data-binary '{"collector_id": "246", "recipients": [{"email": "xyzstannis@surveymonkey.com", "first_name": "Stannis", "last_name": "Baratheon", "custom_id": "94301"}, {"email": "xyzjoffrey@surveymonkey.com", "first_name": "Joffrey", "last_name": "Baratheon", "custom_id": "94401"}, {"email": "renly@surveymonkey"}]}'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateRecipients_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a survey based on template or existing survey.
        /// Notes
        ///     You cannot specify both template\_id and from\_survey\_id
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/create_survey?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/create_survey?api_key=your_api_key --data-binary '{"template_id": "568", "survey_title": "Ice and Fire Event"}'
        /// </summary>
        private void BtnCreateSurvey_Click(object sender, EventArgs e)
        {
            CreateSurveyResponse survey;
            BasicRequestData brd = GetRequestFields();

            survey = SurveyRequest.CreateSurvey(brd);

            lblStatus.Text = survey.Status.ToString();
            lblErrorMsg.Text = survey.ErrorMessage;

            List<SurveyInfo> sInfoList = new List<SurveyInfo>();
            try
            {
                sInfoList.Add(survey.Survey);
                dgvSurveyList.DataSource = sInfoList;
            }
            catch { } // do nothing

        }


        /// <summary>
        /// Create an email message.
        /// Notes
        ///     body\_html overrides body\_text in the email message sent to recipients
        /// Endpoint : https://api.surveymonkey.net/v2/emails/create_email_message?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/create_email_message?api_key=your_api_key --data-binary '{"collector_id":"123", "email_message":{ "subject" : "Ice and Fire event" , "reply_email" : "xyzcersei@surveymonkey.com", "body_text" : "We are conducting a survey, and your response would be appreciated. Here is a link to the survey: [SurveyLink] This link is uniquely tied to this survey and your email address. Please do not forward this message. Thanks for your participation! Please note: If you do not wish to receive further emails from us, please click the link below, and you will be automatically removed from our mailing list. [RemoveLink]"}}'
        /// </summary>
        private void BtnCreateEmailMessage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a paged list of templates provided by Survey Monkey.
        /// Notes
        ///     If templates are returned that the user cannot access, the `upgrade_info` dictionary will be returned
        /// Endpoint : https://api.surveymonkey.net/v2/templates/get_template_list?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/templates/get_template_list?api_key=your_api_key --data-binary '{"page": 1, "page_size": 10, "language_id": 1, "category_id": "131", "fields" : ["title"]}'
        /// </summary>
        private void BtnGetTemplateList_Click(object sender, EventArgs e)
        {
            GetTemplateListResponse templates;
            BasicRequestData brd = GetRequestFields();

            if (chkFull.Checked)
            {
                templates = SurveyRequest.GetTemplateListFull(brd);
            }
            else
            {
                templates = SurveyRequest.GetTemplateList(brd);
            }

            lblStatus.Text = templates.Status.ToString();
            lblErrorMsg.Text = templates.ErrorMessage;

            try
            {
                dgvSurveyList.DataSource = templates.TemplateListResult.TemplateInfoList;
            }
            catch { } // do nothing
        }

        /// <summary>
        /// Create a weblink collector.
        /// Notes
        ///     Basic users can create a maximum of 3 collectors per survey
        /// Endpoint : https://api.surveymonkey.net/v2/collectors/create_collector?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/collectors/create_collector?api_key=your_api_key --data-binary '{"survey_id": "100399456", "collector":{"type": "weblink", "name": "My Collector"}}'
        /// </summary>
        private void BtnCreateCollector_Click(object sender, EventArgs e)
        {
            CreateCollectorResponse collector;
            CreateCollectorRequest brd = GetCCRequestFields();
            
            collector = SurveyRequest.CreateCollector(brd);
            
            lblStatus.Text = collector.Status.ToString();
            lblErrorMsg.Text = collector.ErrorMessage;

            try
            {
                List<CollectorInfo> ciList = new List<CollectorInfo>();
                ciList.Add(collector.CollectorResult.Collector);
                dgvSurveyList.DataSource = ciList;
            }
            catch { } // do nothing
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
        private void BtnGetRespondentList_Click(object sender, EventArgs e)
        {
            GetRespondentListResponse respondent;
            BasicRequestData brd = GetRequestFields();

            if (brd.SurveyID == null)
            {
                MessageBox.Show("no survey id specified.  Going to get error back.");
            }

            if (chkFull.Checked)
            {
                respondent = SurveyRequest.GetRespondentListFull(brd);
            }
            else
            {
                respondent = SurveyRequest.GetRespondentList(brd);
            }

            lblStatus.Text = respondent.Status.ToString();
            lblErrorMsg.Text = respondent.ErrorMessage;

            try
            {
                dgvSurveyList.DataSource = respondent.RespondantListResult.RespondantList;
            }
            catch { } // do nothing
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
        private void BtnGetResponses_Click(object sender, EventArgs e)
        {
            GetSurveyDetailsResponse surveyDetails;
            GetResponsesResponse responses;
            GetRespondentListResponse respondent;

            BasicRequestData brd = GetRequestFields();
            SurveyQuestionView surveyView = new SurveyQuestionView();
            ResponseView responseView = new ResponseView();

            if (brd.SurveyID == null)
            {
                MessageBox.Show("no survey id specified.  Going to get error back.");
            }

            try
            {
                if ((brd.RespondentIDList == null) && (brd.RespondentIDList.Length == 0))
                {
                    MessageBox.Show("no respondants specified.  May be error, or empty return.");
                }

                surveyDetails = SurveyRequest.GetSurveyDetails(brd);
                respondent = SurveyRequest.GetRespondentListFull(brd);
                responses = SurveyRequest.GetResponses(brd);
                surveyView.LoadSurvey(surveyDetails);

                responseView.Flatten(responses.ResponseResultList, respondent.RespondantListResult.RespondantList, surveyView);

                //List<ResponseWithAnswer> ResponseAnswerList { get; set; }


                lblStatus.Text = respondent.Status.ToString();
                lblErrorMsg.Text = respondent.ErrorMessage;

                try
                {
                    dgvSurveyList.DataSource = responseView.ResponseAnswerList; //respondent.ResponseResultList;
                }
                catch { } // do nothing
            }
            catch
            {
                MessageBox.Show("ERROR with respondants specified.  No data submitted to SurveyMonkey");
            }
        }

        /// <summary>
        /// Returns how many respondents have started and/or completed the survey for the given collector.
        /// Endpoint : https://api.surveymonkey.net/v2/surveys/get_response_counts?api_key=your_api_key
        /// Example Request
        /// curl -H 'Authorization:bearer XXXYYYZZZ' -H 'Content-Type: application/json' https://api.surveymonkey.net/v2/surveys/get_response_counts/?api_key=your_api_key --data-binary '{"collector_id": "23907195"}'
        /// </summary>
        private void BtnGetResponseCounts_Click(object sender, EventArgs e)
        {
            GetResponseCountsResponse respondent;
            BasicRequestData brd = GetRequestFields();

            if (brd.CollectorID == null)
            {
                MessageBox.Show("no collector id specified.  Going to get error back.");
            }

            try
            {
                respondent = SurveyRequest.GetResponseCounts(brd);
            
                lblStatus.Text = respondent.Status.ToString();
                lblErrorMsg.Text = respondent.ErrorMessage;

            
                List<GetResponseCountsResult> rList = new List<GetResponseCountsResult>();
                rList.Add(respondent.ResponseCountResult);
                dgvSurveyList.DataSource = rList;
            }
            catch { } // do nothing
        }

        /// <summary>
        /// Returns a summary of how respondents answered each question, including counts and average ratings
        /// </summary>
        private void BtnGetResponseSummary_Click(object sender, EventArgs e)
        {
            GetSurveyDetailsResponse surveyDetails;
            GetResponsesResponse responses;
            GetRespondentListResponse respondent;

            BasicRequestData brd = GetRequestFields();
            brd.PageSize = 1000; // get all respondents
            SurveyQuestionView surveyView = new SurveyQuestionView();
            ResponseView responseView = new ResponseView();

            if (brd.SurveyID == null)
            {
                MessageBox.Show("no survey id specified.  Going to get error back.");
            }

            try
            {
                surveyDetails = SurveyRequest.GetSurveyDetails(brd);
                respondent = SurveyRequest.GetRespondentListFull(brd);

                List<string> respondantID = new List<string>();
                bool isProcessed = false;
                responses = new GetResponsesResponse();
                foreach (RespondentInfo rInfo in respondent.RespondantListResult.RespondantList)
                {
                    respondantID.Add(rInfo.RespondentID);
                    // maximum number of respondents that can be processed is 100
                    if (respondantID.Count == 100)
                    {
                        brd.RespondentIDList = respondantID.ToArray();
                        responses = GetRespondenses(responses, brd, isProcessed);
                        isProcessed = true;
                        respondantID.Clear();
                    }
                }
                if (respondantID.Count > 0) brd.RespondentIDList = respondantID.ToArray();

                responses = GetRespondenses(responses, brd, isProcessed);
                surveyView.LoadSurvey(surveyDetails);
                responseView.LoadResponseSummary(responses.ResponseResultList, surveyView);

                lblStatus.Text = respondent.Status.ToString();
                lblErrorMsg.Text = respondent.ErrorMessage;

                try
                {
                    dgvSurveyList.DataSource = responseView.SurveyWithAnswers; //respondent.ResponseResultList;

                    // update database with survey results
                    
                }
                catch { } // do nothing

            }
            catch
            {
                MessageBox.Show("ERROR with respondants specified.  No data submitted to SurveyMonkey");
            }
        }

        private void DBSurveyResponseUpdate(GetSurveyDetailsResponse surveyDetails, List<QuestionAnswerFlat> surveyWithAnswers)
        {
            string SurveyID = surveyDetails.SurveyDetailsResult.SurveyID;
            foreach(PageInfo pInfo in surveyDetails.SurveyDetailsResult.PageList)
            {
                string PageID = pInfo.PageID;
                string PageHeading = pInfo.Heading;
                int questionsPerPage = 0;
                double pageRankSum = 0;
                foreach(QuestionInfo qInfo in pInfo.QuestionList)
                {
                    int partsPerQuestion = 0;
                    double questionRankSum = 0;
                    if(qInfo.QuestionType.Subtype == QuestionSubtypeEnum.Rating || qInfo.QuestionType.Subtype == QuestionSubtypeEnum.Ranking)
                    {
                        List<QuestionAnswerFlat> qRatingsList = surveyWithAnswers.Where(e => e.QuestionID == qInfo.QuestionID).ToList<QuestionAnswerFlat>();
                        foreach(QuestionAnswerFlat qaf in qRatingsList)
                        {
                            if(qaf.AnswerType == AnswerTypeEnum.Row)
                            {
                                questionRankSum += qaf.RankAvg;
                                partsPerQuestion++;
                            }
                        }
                    }
                    double questionRankAvg = questionRankSum / partsPerQuestion;
                    // Write survey results to database.
                    //Survey.SurveyResponseUpdate(SurveyID, qInfo.QuestionID, PageHeading, PageID, questionRankAvg, connString);
                    questionsPerPage += partsPerQuestion;
                    pageRankSum += questionRankSum;
                }
                double pageRankAvg = pageRankSum / questionsPerPage;
                // Write survey page summary to database.
                //Survey.SurveyResponseUpdate(SurveyID, "", PageHeading, PageID, pageRankAvg, connString);
            }
        }

        /// <summary>
        /// Adds new ResponseResults to the existing list
        /// </summary>
        /// <param name="responses">batch of responses to a survey</param>
        /// <param name="brd"></param>
        /// <param name="isProcessed">Whether the first hundred responses have been processed</param>
        /// <returns></returns>
        private GetResponsesResponse GetRespondenses(GetResponsesResponse responses, BasicRequestData brd, bool isProcessed)
        {
            if (!isProcessed)
            {
                return SurveyRequest.GetResponses(brd);
            }
            else
            {
                GetResponsesResponse temp = SurveyRequest.GetResponses(brd);
                List<GetResponsesResult> newResponsesResultList = new List<GetResponsesResult>();
                newResponsesResultList.AddRange(responses.ResponseResultList);
                newResponsesResultList.AddRange(temp.ResponseResultList);
                responses.ResponseResultList = newResponsesResultList.ToArray();
                return responses;
            }
        }

        /// <summary>
        /// Gets information from create collector fields
        /// </summary>
        /// <returns></returns>
        private CreateCollectorRequest GetCCRequestFields()
        {
            CreateCollectorRequest frd = new CreateCollectorRequest();

            if (txtSurveyID.Text.Trim().Length > 0)
            {
                frd.SurveyID = txtSurveyID.Text;
            }
            else
            {
                frd.SurveyID = null;
            }

            if (txtCollectorName.Text.Trim().Length > 0)
            {
                frd.Collector.Name = txtCollectorName.Text.Trim();
            }

            if (txtCollectorThanks.Text.Trim().Length > 0)
            {
                frd.Collector.ThankYouMsg = txtCollectorThanks.Text.Trim();
            }
            
            if (txtCollectorURL.Text.Trim().Length > 0)
            {
                frd.Collector.RedirectURL = txtCollectorURL.Text.Trim();
            }

            return frd;
        }

        /// <summary>
        /// Get information from the pop-up forms
        /// </summary>
        /// <returns></returns>
        private BasicRequestData GetRequestFields()
        {
            BasicRequestData brd = new BasicRequestData();
            try
            {
                brd.Page = int.Parse(txtPage.Text);
            }
            catch
            {
                brd.Page = 1;
            }

            try
            {
                brd.PageSize = int.Parse(txtPageSize.Text);
            }
            catch
            {
                brd.PageSize = 20;
            }

            if (txtSurveyID.Text.Trim().Length > 0)
            {
                brd.SurveyID = txtSurveyID.Text;
            }
            else
            {
                brd.SurveyID = null;
            }

            if (txtTemplateID.Text.Trim().Length > 0)
            {
                brd.TemplateID = txtTemplateID.Text;
            }
            else
            {
                brd.TemplateID = null;
            }

            if (txtCollectorID.Text.Trim().Length > 0)
            {
                brd.CollectorID = txtCollectorID.Text;
            }
            else
            {
                brd.CollectorID = null;
            }

            if (txtSurveyName.Text.Trim().Length > 0)
            {
                brd.SurveyTitle = txtSurveyName.Text;
            }

            List<string> respondantID = new List<string>();
            if (txtResID1.Text.Trim().Length > 0)
            {
                respondantID.Add(txtResID1.Text);
            }
            if (txtResID2.Text.Trim().Length > 0)
            {
                respondantID.Add(txtResID2.Text);
            }
            if (txtResID3.Text.Trim().Length > 0)
            {
                respondantID.Add(txtResID3.Text);
            }
            if (txtResID4.Text.Trim().Length > 0)
            {
                respondantID.Add(txtResID4.Text);
            }

            if (respondantID.Count > 0) brd.RespondentIDList = respondantID.ToArray();

            return brd;
        }
    }
}
