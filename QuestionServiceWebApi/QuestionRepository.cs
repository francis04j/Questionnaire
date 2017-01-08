using System.Collections.Generic;
using QuestionServiceWebApi.Interfaces;

namespace QuestionServiceWebApi
{
    public class QuestionRepository : IQuestionRepository
    {
        public Questionnaire GetQuestionnaire()
        {
            return new Questionnaire
            {
                QuestionnaireTitle = "Geography Questions",
                QuestionsText = new List<string>
                                           {
                                               "What is the capital of Cuba?",
                                               "What is the capital of France?",
                                               "What is the capital of Poland?",
                                               "What is the capital of Germany?"
                                           },
                Answer = new List<string>() { "Paris","Budapest","London","Dublin"}
            };
        }

        public class Question
        {
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }
            public int AnswerId { get; set; }
        }

        public class Answer
        {
            public int AnswerId { get; set; }
            public string AnswerText { get; set; }
            public int QuestionId { get; set; }
        }
    }
}