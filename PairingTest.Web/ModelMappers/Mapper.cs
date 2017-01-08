using System.Collections.Generic;
using System.Linq;
using PairingTest.Web.ApiWrapper.Models;
using PairingTest.Web.Models;

namespace PairingTest.Web.ModelMappers
{
    public class Mapper : IMapper
    {
        public QuestionnaireViewModel MapFrom(QuestionairesResultModel apiModel)
        {
            var viewModel = new QuestionnaireViewModel()
            {
                QuestionnaireTitle = apiModel.QuestionnaireTitle,
                
            };
            foreach (var qs in apiModel.QuestionsText)
            {
                //foreach (var ans in apiModel.Answer)
                    //viewModel.QuestionAnswers.Add(
                var qa = new QuestionAnswer() {QuestionText = qs};
                qa.Answer = new List<Answer>();
                foreach (var ans in apiModel.Answer)
                {
                    qa.Answer.Add(new Answer() {AnswerText = ans});
                }
                viewModel.QuestionAnswers.Add(qa);
            }
            return viewModel;
        }
    }
}