using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using PairingTest.Web.ApiWrapper.Models;

namespace PairingTest.Web.ApiWrapper
{
    public class QuestionaireApiWrapper : IQuestionaireApiWrapper
    {
        readonly IHttpClientWrapper httpClientWrapper;
        readonly IQueryResultBuilder queryResultBuilder;
        

        public QuestionaireApiWrapper(IHttpClientWrapper httpClientWrapper, IQueryResultBuilder queryResultBuilder)
        {
            this.httpClientWrapper = httpClientWrapper;
            this.queryResultBuilder = queryResultBuilder;
        }

        public async Task<QuestionairesResultModel> GetQuestions()
        {
            var httpResponseMessage = await httpClientWrapper.GetAsync();
            return BuildQueryResult<QuestionairesResultModel>(httpResponseMessage);
        }

        private TResult BuildQueryResult<TResult>(HttpResponseMessage httpResponseMessage) where TResult : class, new()
        {
            var sss=  queryResultBuilder.BuildQueryResult<TResult>(httpResponseMessage);
            return sss;
        }
    }
}