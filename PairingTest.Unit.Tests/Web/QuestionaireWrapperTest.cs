using System.Linq;
using System.Net;
using System.Net.Http;
using Moq;
using NUnit.Framework;
using PairingTest.Web.ApiWrapper;
using PairingTest.Web.ApiWrapper.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionaireWrapperTest
    {
        readonly IQuestionaireApiWrapper apiWrapper;
        readonly Mock<IHttpClientWrapper> httpClientWrapper;
        readonly Mock<IQueryResultBuilder> queryResultBuilder;
        readonly HttpResponseMessage successHttpResponseMessage;
        readonly HttpResponseMessage failHttpResponseMessage;
        

        public QuestionaireWrapperTest()
        {
            successHttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            failHttpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            httpClientWrapper = new Mock<IHttpClientWrapper>();
            queryResultBuilder = new Mock<IQueryResultBuilder>();
            apiWrapper = new QuestionaireApiWrapper(httpClientWrapper.Object, queryResultBuilder.Object);
        }

        [Test]
        public void ShouldReturnQuestionsWithNoErros()
        {
            var expectedResult = new QuestionairesResultModel() { QuestionnaireTitle = "Expected Title"};
            httpClientWrapper.Setup(x => x.GetAsync()).ReturnsAsync(successHttpResponseMessage);
            queryResultBuilder.Setup(x => x.BuildQueryResult<QuestionairesResultModel>(successHttpResponseMessage)).Returns(expectedResult);
            var result = apiWrapper.GetQuestions().Result;

            Assert.IsFalse(result.Errors.Any());
            Assert.IsInstanceOf<QueryResult>(result);
        }

        [Test]
        public void ShouldReturnErrorsIfFailure()
        {
            var expectedResult = new QuestionairesResultModel(new QueryError());
            httpClientWrapper.Setup(x => x.GetAsync()).ReturnsAsync(failHttpResponseMessage);
            queryResultBuilder.Setup(x => x.BuildQueryResult<QuestionairesResultModel>(failHttpResponseMessage)).Returns(expectedResult);
            var result = apiWrapper.GetQuestions().Result;

            Assert.IsTrue(result.Errors.Any());
        }
    }
}
