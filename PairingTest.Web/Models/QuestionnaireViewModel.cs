using System.Collections.Generic;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel
    {
        public QuestionnaireViewModel()
        {
            QuestionAnswers = new List<QuestionAnswer>();
        }

        public string QuestionnaireTitle { get; set; }
        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }

    public class QuestionAnswer
    {
        public string QuestionText { get; set; }
        public List<Answer> Answer { get; set; }
        public string Selected { get; set; }
    }

    public class Answer
    {
        public string AnswerText { get; set; }
        public bool Selected { get; set; }
    }
}