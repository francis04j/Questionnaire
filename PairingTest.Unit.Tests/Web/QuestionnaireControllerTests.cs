using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PairingTest.Web.ApiWrapper;
using PairingTest.Web.ApiWrapper.Models;
using PairingTest.Web.Controllers;
using PairingTest.Web.ModelMappers;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        readonly Mock<IQuestionaireApiWrapper> apiWrapper;
        readonly IMapper mapper;

        public QuestionnaireControllerTests()
        {
            mapper = new Mapper();
            apiWrapper = new Mock<IQuestionaireApiWrapper>();
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var QuestionnaireTitle = "My expected quesitons";
            var QuestionsText = new List<string>() {"Is this my expected question?"};
            var expectedQuestion = new QuestionairesResultModel()
            {
                QuestionnaireTitle = QuestionnaireTitle,
                QuestionsText = QuestionsText
            };
            
            apiWrapper.Setup(x => x.GetQuestions()).ReturnsAsync(expectedQuestion);
            var questionnaireController = new QuestionnaireController(apiWrapper.Object,mapper);

            //Act
            var result = questionnaireController.Index().Result.ViewData.Model as QuestionnaireViewModel;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.QuestionAnswers.Any());
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedQuestion.QuestionnaireTitle));
            Assert.That(result.QuestionAnswers.First().QuestionText, Is.EqualTo(expectedQuestion.QuestionsText.First()));

        }

        [Test]
        public void ShouldGetNoQuestionsIfError()
        {
            var expectedApiResponse = new QuestionairesResultModel(new QueryError("Some error"));
            apiWrapper.Setup(x => x.GetQuestions()).ReturnsAsync(expectedApiResponse);
            var questionnaireController = new QuestionnaireController(apiWrapper.Object, mapper);
            
            var result = questionnaireController.Index().Result.ViewData.Model as QuestionnaireViewModel;

            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.QuestionnaireTitle));
        }
    }
}