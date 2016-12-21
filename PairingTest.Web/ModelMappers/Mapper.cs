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
                QuestionsText = apiModel.QuestionsText
            };
            return viewModel;
        }
    }
}