using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using PairingTest.Web.ApiWrapper;
using PairingTest.Web.ApiWrapper.Models;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class ApiResultBuilderTests
    {
        [Test]
        public void SuccessfullServiceResponseWithContentReturnsQueryResultWithNoErrors()
        {
            var expectedQuestionaire = new Questionnaire()
            {
                QuestionnaireTitle = "Title",
                QuestionsText = new List<string>() {"Is this the right question?"}
            };
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedQuestionaire))
            };

            var result = new QueryResultBuilder().BuildQueryResult<QuestionairesResultModel>(httpResponseMessage);
            Assert.IsFalse(result.Errors.Any());
            Assert.AreEqual(expectedQuestionaire.QuestionnaireTitle, result.QuestionnaireTitle);
        }

        [Test]
        public void SuccessfullServiceResponseWithNoContentReturnsQueryResultWithNoErrors()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ }")
            };

            var result = new QueryResultBuilder().BuildQueryResult<QuestionairesResultModel>(httpResponseMessage);

            Assert.IsFalse(result.Errors.Any());
        }

        [Test]
        public void FailedServiceResponseReturnsQueryResultWithErrors()
        {
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new QueryResult(new QueryError("someError"))))
            };

            var result = new QueryResultBuilder().BuildQueryResult<QueryResult>(httpResponseMessage);

            Assert.IsTrue(result.Errors.Any());
        }
    }
}
