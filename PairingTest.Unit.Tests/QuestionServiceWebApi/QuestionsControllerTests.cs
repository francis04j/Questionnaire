using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected questions";
            var expectedQuestions = new Questionnaire() {QuestionnaireTitle = expectedTitle,QuestionsText = new List<string>() {"Questions"} };
            var fakeQuestionRepository = new FakeQuestionRepository() {ExpectedQuestions = expectedQuestions};
            var questionsController = new QuestionsController(fakeQuestionRepository);

            //Act
            var questions = questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.IsTrue(questions.QuestionsText.Any());
            
        }
    }
}