using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyMonkey.Containers;
using SurveyMonkey.Responses;

namespace SurveyMonkey.Views
{
    /// <summary>
    /// View that handles parsing information about a survey
    /// </summary>
    public class SurveyQuestionView
    {
        public string SurveyID { get; set; }
        public List<QuestionInfo> QuestionList { get; set; }

        public List<QuestionAnswerFlat> SurveyWithAnswers { get; set; }
        
        /// <summary>
        /// Turn a detail survey response into a survey id with a list of associated questions and answers.
        /// </summary>
        /// <param name="surveyDetailResponse">Has all data regarding the survey</param>
        public void LoadSurvey(GetSurveyDetailsResponse surveyDetailResponse)
        {
            int questionNumber = 0;
            List<QuestionInfo> qList = new List<QuestionInfo>();
            List<QuestionAnswerFlat> qafList = new List<QuestionAnswerFlat>();

            SurveyID = surveyDetailResponse.SurveyDetailsResult.SurveyID;
            foreach(PageInfo surveyPage in surveyDetailResponse.SurveyDetailsResult.PageList)
            {
                foreach(QuestionInfo pageQuestion in surveyPage.QuestionList.OrderBy(e => e.Position))
                {
                    string row = "0";
                    string col = "0";
                    qList.Add(pageQuestion);
                    questionNumber++;
                    foreach (AnswerInfo questionAnswer in pageQuestion.QuestionAnswerList.OrderBy(e => e.Position))
                    {
                        if (questionAnswer.AnswerType == AnswerTypeEnum.Row)
                        {
                            row = questionAnswer.AnswerID;
                        }
                        if (questionAnswer.AnswerType == AnswerTypeEnum.Column)
                        {
                            col = questionAnswer.Column;
                        }
                        QuestionAnswerFlat qaf = new QuestionAnswerFlat();
                        qaf.AnswerID = questionAnswer.AnswerID;
                        qaf.AnswerNumber = questionAnswer.Position;
                        qaf.AnswerText = questionAnswer.Text;
                        qaf.AnswerType = questionAnswer.AnswerType;
                        qaf.AnswerVisible = questionAnswer.Visible;
                        qaf.QuestionID = pageQuestion.QuestionID;
                        qaf.QuestionNumber = questionNumber;
                        qaf.QuestionSubtype = pageQuestion.QuestionType.Subtype;
                        qaf.QuestionText = pageQuestion.Heading;
                        qaf.QuestionType = pageQuestion.QuestionType.Family;
                        qaf.Column = col;
                        qaf.Row = row;
                        qaf.Weight = questionAnswer.Weight;
                        qafList.Add(qaf);
                    }
                }
            }

            QuestionList = qList;
            SurveyWithAnswers = qafList;
        }
    }

    /// <summary>
    /// Contains flattened information about the answer and its corresponding question
    /// </summary>
    public class QuestionAnswerFlat
    {
        public string QuestionText { get; set; }
        public int QuestionNumber { get; set; }
        public string QuestionID { get; set; }
        public QuestionFamilyEnum QuestionType { get; set; }
        public QuestionSubtypeEnum QuestionSubtype { get; set; }

        public string AnswerID { get; set; }
        public string AnswerText { get; set; }
        public int AnswerNumber { get; set; }
        public AnswerTypeEnum AnswerType { get; set; }
        public bool AnswerVisible { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }
        public int Weight { get; set; }
        public int TotalResponses { get; set; }
        public int Count { get; set; }
        public double RankAvg { get; set; }
        public RankTypeEnum RankType { get; set; }
    }
}
