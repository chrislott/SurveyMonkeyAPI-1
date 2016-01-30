using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyMonkey.Containers;
using SurveyMonkey.Responses;
using System.Text.RegularExpressions;

namespace SurveyMonkey.Views
{
    /// <summary>
    /// Handles responses to specific surveys and organizes data into meaningful overview objects
    /// </summary>
    public class ResponseView
    {
        public List<ResponseWithAnswer> ResponseAnswerList { get; set; }
        public List<QuestionAnswerFlat> SurveyWithAnswers { get; set; }

        /// <summary>
        ///  Shows each respondent's answer to each question in a survey
        /// </summary>
        /// <param name="ResponseResultList">A list of responses from each person who responded to the survey</param>
        /// <param name="RespondentList">A list of respondents who answered the survey</param>
        /// <param name="SurveyQuestions">Contains a list of questions and a list of answers for each question/param>
        public void Flatten(GetResponsesResult[] ResponseResultList, RespondentInfo[] RespondentList, SurveyQuestionView SurveyQuestions)
        {
            List<ResponseWithAnswer> rwaList = new List<ResponseWithAnswer>();

            foreach (GetResponsesResult response in ResponseResultList)
            {
                List<RespondentInfo> rList = RespondentList.Where(e => e.RespondentID == response.RespondentID).ToList<RespondentInfo>();
                if (rList != null)
                {
                    RespondentInfo respondant = rList[0];
                    foreach (QuestionInfo qInfo in response.QuestionList)
                    {
                        List<QuestionInfo> question = SurveyQuestions.QuestionList.Where(e => e.QuestionID == qInfo.QuestionID).ToList<QuestionInfo>();
                        QuestionInfo responseQuestion = question[0];
                        qInfo.QuestionType = responseQuestion.QuestionType;

                        foreach (AnswerInfo aInfo in qInfo.QuestionAnswerList)
                        {


                            ResponseWithAnswer rwa = new ResponseWithAnswer();

                            AnswerInfo qi = new AnswerInfo();
                            QuestionFamilyEnum qaFamily = responseQuestion.QuestionType.Family;
                            switch (qaFamily)
                            {
                                case QuestionFamilyEnum.SingleChoice:
                                    rwa.Answer = ProcessAnswer(responseQuestion, aInfo);
                                    break;
                                case QuestionFamilyEnum.MultipleChoice:
                                    rwa.Answer = ProcessAnswer(responseQuestion, aInfo);
                                    break;
                                case QuestionFamilyEnum.Matrix:
                                    rwa.Row = ProcessRow(responseQuestion, aInfo);
                                    rwa.Answer = ProcessAnswer(responseQuestion, aInfo);
                                    break;
                                case QuestionFamilyEnum.OpenEnded:
                                    rwa.Answer = aInfo.Text;
                                    break;
                                case QuestionFamilyEnum.DateTime:
                                    rwa.Row = ProcessRow(responseQuestion, aInfo);
                                    rwa.Answer = aInfo.Text;
                                    break;
                                case QuestionFamilyEnum.Demographic:
                                    rwa.Row = ProcessRow(responseQuestion, aInfo);
                                    rwa.Answer = aInfo.Text;
                                    break;
                                case QuestionFamilyEnum.NotSet:
                                    break;
                                case QuestionFamilyEnum.Presentation:
                                    break;
                                case QuestionFamilyEnum.CustomVariable:
                                    break;
                                default: rwa.Answer = "Answer choice cannot be found in answer bank for this question";
                                    break;

                            }

                            rwa.Question = responseQuestion.Heading;
                            rwa.QuestionID = responseQuestion.QuestionID;
                            rwa.QuestionSubtype = responseQuestion.QuestionType.Subtype;
                            rwa.QuestionType = qaFamily;


                            rwa.User = respondant.Email;
                            rwa.RespondentID = respondant.RespondentID;
                            rwa.RecipientID = respondant.RecipientID;
                            rwaList.Add(rwa);

                        }
                    }
                }
            }

            ResponseAnswerList = rwaList;
        }

        /// <summary>
        /// Processes Answer information for answers that only have one parameter to determine their value
        /// </summary>
        /// <param name="responseQuestion"></param>
        /// <param name="aInfo"></param>
        /// <returns></returns>
        private string ProcessAnswer(QuestionInfo responseQuestion, AnswerInfo aInfo)
        {
            AnswerInfo qi = new AnswerInfo();
            QuestionSubtypeEnum qaSubtype = responseQuestion.QuestionType.Subtype;
            if (qaSubtype == QuestionSubtypeEnum.Menu || qaSubtype == QuestionSubtypeEnum.Vertical || qaSubtype == QuestionSubtypeEnum.Horizontal)
            {
                qi = responseQuestion.QuestionAnswerList.Where(e => e.AnswerID == aInfo.Row).FirstOrDefault<AnswerInfo>();
            }
            if (qaSubtype == QuestionSubtypeEnum.Ranking || qaSubtype == QuestionSubtypeEnum.Rating)
            {
                qi = responseQuestion.QuestionAnswerList.Where(e => e.AnswerID == aInfo.Column).FirstOrDefault<AnswerInfo>();
            }

            // for optional comments in Matrices
            if(qi != null) return qi.Text;
            
            else return aInfo.Text;
        }

        /// <summary>
        /// Processes Row information for answers that have two parameters to determine their value
        /// </summary>
        /// <param name="responseQuestion"></param>
        /// <param name="aInfo"></param>
        /// <returns></returns>
        private string ProcessRow(QuestionInfo responseQuestion, AnswerInfo aInfo)
        {
            AnswerInfo qRow = new AnswerInfo();
            QuestionSubtypeEnum qaSubtype = responseQuestion.QuestionType.Subtype;
            // Demographic QuestionFamily types have extra spaces and newlines in front and back of their answer text
            if(qaSubtype == QuestionSubtypeEnum.International)
            {
                qRow = responseQuestion.QuestionAnswerList.Where(e => e.AnswerID == aInfo.Row).FirstOrDefault<AnswerInfo>();
                return qRow.Text.Trim('\n').Trim();
            }
            else qRow = responseQuestion.QuestionAnswerList.Where(e => e.AnswerID == aInfo.Row).FirstOrDefault<AnswerInfo>();

            // for optional comments in Matrices
            if(qRow != null) return qRow.Text;
            
            else return responseQuestion.QuestionAnswerList[0].Text;
        }

        /// <summary>
        /// Loads a summary of the responses to each question answer, including counts and averages based on survey responses
        /// </summary>
        /// <param name="ResponseResultList">A list of responses from each person who responded to the survey</param>
        /// <param name="surveyQuestions">Contains a list of questions and a list of answers for each question/param>
        public void LoadResponseSummary(GetResponsesResult[] ResponseResultList, SurveyQuestionView surveyQuestions)
        {
            List<QuestionInfo> qList = new List<QuestionInfo>();
            List<QuestionAnswerFlat> qafList = new List<QuestionAnswerFlat>();
            string qafQuestionID = "";
            int totalResponses = 0;

            foreach (QuestionAnswerFlat qaf in surveyQuestions.SurveyWithAnswers)
            {
                if(qafQuestionID != qaf.QuestionID) // only recalculate if it is a new question
                {
                    // Calculate total number of responses for each question in case not everyone answers every question
                    qafQuestionID = qaf.QuestionID;
                    totalResponses = GetTotalResponses(qaf, ResponseResultList);
                }
                qaf.TotalResponses = totalResponses;
                QuestionAnswerFlat qafSummary = GetQuestionAnswerSummary(qaf, ResponseResultList, surveyQuestions, false);

                qafList.Add(qaf);
            }

            SurveyWithAnswers = qafList;
        }

        /// <summary>
        /// Gets a summary of the responses for a particular question answer, including counts and averages based on survey responses
        /// </summary>
        /// <param name="qaf">The question answer choice to get a summary of responses about</param>
        /// <param name="ResponseResultList">A list of responses from each person who responded to the survey</param>
        /// <param name="surveyQuestions">Contains a list of questions and a list of answers for each question</param>
        /// <param name="calcTotalResponses">"True" when the totalResponses for this question is unknown</param>
        /// <returns>An object that contains all of the summary data</returns>
        public QuestionAnswerFlat GetQuestionAnswerSummary(QuestionAnswerFlat qaf, GetResponsesResult[] ResponseResultList, SurveyQuestionView surveyQuestions, bool calcTotalResponses = true)
        {
            // Calculate total number of responses if it is not provided
            if (qaf.TotalResponses == 0)
            {
                qaf.TotalResponses = GetTotalResponses(qaf, ResponseResultList);
            }

            CountAndAverage caa = GetCountAndAverage(qaf, ResponseResultList, surveyQuestions);

            qaf.Count = caa.Count; 
            qaf.RankAvg = caa.RankAvg;
            qaf.RankType = GetRankType(qaf);

            return qaf;
        }

        /// <summary>
        /// Gets the number of responses for the particular question of the questionAnswer
        /// </summary>
        /// <param name="qaf">The question answer choice to get a summary of responses about</param>
        /// <param name="ResponseResultList">A list of responses from each person who responded to the survey</param>
        /// <returns>The number of total responses to this question</returns>
        public int GetTotalResponses(QuestionAnswerFlat qaf, GetResponsesResult[] ResponseResultList)
        {
            int totalResponses = 0;
            foreach (GetResponsesResult response in ResponseResultList)
            {
                List<QuestionInfo> QuestionResponsesList = response.QuestionList.Where(e => e.QuestionID == qaf.QuestionID).ToList<QuestionInfo>();

                if (QuestionResponsesList.Count > 0)
                {
                    // Do not count answers with optional comments
                    if (qaf.QuestionSubtype == QuestionSubtypeEnum.Rating || qaf.QuestionSubtype == QuestionSubtypeEnum.Ranking)
                    {
                        // optional comments have no column value, all other answers in a Matrix have both a column and row value
                        List<AnswerInfo> QuestionResponsesWithoutOptionalCommentsList = QuestionResponsesList[0].QuestionAnswerList.Where(e => e.Column != null).ToList<AnswerInfo>();
                        totalResponses += QuestionResponsesWithoutOptionalCommentsList.Count;
                    }
                    else
                        if (qaf.QuestionType == QuestionFamilyEnum.Demographic || qaf.QuestionType == QuestionFamilyEnum.DateTime)
                        {
                            totalResponses = ResponseResultList.Length;
                            break;
                        }
                        else
                        {
                            totalResponses += QuestionResponsesList[0].QuestionAnswerList.Length;
                        }
                }
            }
            return totalResponses;
        }

        /// <summary>
        /// Gets the count and rankAverage for a question answer
        /// </summary>
        /// <param name="qaf">The question answer choice to get a summary of responses about</param>
        /// <param name="ResponseResultList">A list of responses from each person who responded to the survey</param>
        /// <param name="surveyQuestions">Contains a list of questions and a list of answers for each question</param>
        /// <returns>An object that holds both the count and rank average for the question answer</returns>
        public CountAndAverage GetCountAndAverage(QuestionAnswerFlat qaf, GetResponsesResult[] ResponseResultList, SurveyQuestionView surveyQuestions)
        {
            int count = 0;
            double rankSum = 0;
            int NAresponses = 0; // Count to ignore N/A responses when calculating average
            CountAndAverage caa = new CountAndAverage();

            foreach (GetResponsesResult response in ResponseResultList)
            {
                foreach (QuestionInfo qInfo in response.QuestionList)
                {
                    List<AnswerInfo> SQSelect = qInfo.QuestionAnswerList.Where(e => e.Row == qaf.AnswerID || e.Column == qaf.AnswerID).ToList<AnswerInfo>();
                    int SQCount = SQSelect.Count;

                    count += AddCount(qaf, qInfo, SQCount);

                    // for calculating average for rankings and ratings
                    if (SQSelect.Count > 0 && (qaf.QuestionSubtype == QuestionSubtypeEnum.Ranking || qaf.QuestionSubtype == QuestionSubtypeEnum.Rating)
                        && qaf.AnswerType == AnswerTypeEnum.Row)
                    {
                        List<QuestionAnswerFlat> RankSelect = surveyQuestions.SurveyWithAnswers
                                                                .Where(e => e.AnswerID == SQSelect[0].Column)
                                                                .ToList<QuestionAnswerFlat>();

                        rankSum += AddRankSum(qaf, SQSelect, surveyQuestions);

                        if (RankSelect[0].AnswerText == "N/A")
                        {
                            NAresponses++;
                        }

                    }
                }
            }
            caa.Count = count;
            caa.RankAvg = GetRankAvg(rankSum, count, NAresponses, qaf.TotalResponses);
            return caa;
        }

        /// <summary>
        /// Figures out how many times a particular respondent chose this QuestionAnswer
        /// </summary>
        /// <param name="qaf">The question answer to get counts for</param>
        /// <param name="qInfo">The information about how a respondent answered this question</param>
        /// <param name="SQCount">The number of times this answer appears in the respondent's QuestionInfo - but does not catch optional comments</param>
        /// <returns>The number of times this answer appears in the respondent's QuestionInfo - either 0 or 1 </returns>
        private int AddCount(QuestionAnswerFlat qaf, QuestionInfo qInfo, int SQCount)
        {
            // For counting optional comments
            if (SQCount == 0 && qaf.QuestionType == QuestionFamilyEnum.Matrix && qaf.AnswerType == AnswerTypeEnum.Other)
            {
                List<AnswerInfo> SQSelectOptional = qInfo.QuestionAnswerList.Where(e => e.Row == qaf.Column).ToList<AnswerInfo>();
                return SQSelectOptional.Count;
            }
            return SQCount;
        }

        /// <summary>
        /// Firgures out the numerical rank of the question answer
        /// </summary>
        /// <param name="qaf">The question answer to get rankSum for</param>
        /// <param name="SQSelect">Contains the corresponding answer that matches the question asnwer</param>
        /// <param name="surveyQuestions">Contains a list of questions and a list of answers for each question</param>
        /// <returns></returns>
        private int AddRankSum(QuestionAnswerFlat qaf, List<AnswerInfo> SQSelect, SurveyQuestionView surveyQuestions)
        {
            // for calculating average for rankings and ratings
            if (SQSelect.Count > 0 && (qaf.QuestionSubtype == QuestionSubtypeEnum.Ranking || qaf.QuestionSubtype == QuestionSubtypeEnum.Rating)
                && qaf.AnswerType == AnswerTypeEnum.Row)
            {
                //return qaf.Weight;

                List<QuestionAnswerFlat> RankSelect = surveyQuestions.SurveyWithAnswers
                                                        .Where(e => e.AnswerID == SQSelect[0].Column)
                                                        .ToList<QuestionAnswerFlat>();
                // Try to get rank from the weight
                if (qaf.Weight != 0)
                {
                    return qaf.Weight;
                }
                else // if weight not set, take from AnswerNumber
                {
                    return RankSelect[0].AnswerNumber;
                }

            }
            return 0;
        }

        /// <summary>
        /// Calculates the rank average
        /// </summary>
        /// <param name="rankSum">The sum of the ranks chosen for the question</param>
        /// <param name="count">The number of times the answer was chosen</param>
        /// <param name="NAresponses">The number of times respondents answered N/A</param>
        /// <param name="totalResponses">The total number of times the question was answered</param>
        /// <returns>The rank average</returns>
        private double GetRankAvg(double rankSum, int count, int NAresponses, int totalResponses)
        {
            // Calculates either rank average or percent of total answers
            if (count != 0 && rankSum > 0)
            { // rank average
                return Math.Round(rankSum / (count - NAresponses), 3);
            }
            else
            { // percent
                return Math.Round(((double)count) / totalResponses * 100, 3);
            }
        }

        /// <summary>
        /// Determines the rank type of a question answer
        /// </summary>
        /// <param name="qaf">The question answer</param>
        /// <returns>The rank type</returns>
        public RankTypeEnum GetRankType(QuestionAnswerFlat qaf)
        {
            switch (qaf.QuestionSubtype)
            {

                case QuestionSubtypeEnum.Ranking:
                    switch (qaf.AnswerType)
                    {
                        case AnswerTypeEnum.Row:
                            return RankTypeEnum.AvgRanking;
                        case AnswerTypeEnum.Column:
                            return RankTypeEnum.PercentOfResponses;
                        default:
                            break;
                    }
                    break;
                case QuestionSubtypeEnum.Rating:
                    switch (qaf.AnswerType)
                    {
                        case AnswerTypeEnum.Row:
                            return RankTypeEnum.AvgRating;
                        case AnswerTypeEnum.Column:
                            return RankTypeEnum.PercentOfResponses;
                        case AnswerTypeEnum.Other:
                            return RankTypeEnum.PercentFilledOut;
                        default:
                            break;
                    }
                    break;
                case QuestionSubtypeEnum.International:
                    return RankTypeEnum.PercentFilledOut;
                case QuestionSubtypeEnum.Both:
                    return RankTypeEnum.PercentFilledOut;
                default:
                    return RankTypeEnum.PercentOfResponses;
            }
            return RankTypeEnum.NotSet;
        }

        /// <summary>
        /// Contains flattened information about a respondent's answer to a specific question
        /// </summary>
        public class ResponseWithAnswer
        {
            public string QuestionID { get; set; }
            public string RespondentID { get; set; }
            public string RecipientID { get; set; }
            public string User { get; set; }
            public string Question { get; set; }
            public QuestionFamilyEnum QuestionType { get; set; }
            public QuestionSubtypeEnum QuestionSubtype { get; set; }
            public string Row { get; set; }
            public string Answer { get; set; }

        }

        /// <summary>
        /// Contains information about the count and rank average for a particular question answer
        /// </summary>
        public class CountAndAverage
        {
            public int Count { get; set; }
            public double RankAvg { get; set; }
        }
    }
}
