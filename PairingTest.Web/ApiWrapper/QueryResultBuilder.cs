using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace PairingTest.Web.ApiWrapper
{
    public class QueryResultBuilder : IQueryResultBuilder
    {
        public TResult BuildQueryResult<TResult>(HttpResponseMessage httpResponseMessage) where TResult : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<TResult>(httpResponseMessage.Content.ReadAsStringAsync().Result) ??
                       new TResult();
            }
            catch(Exception e)
            {
                //TODO: log error
                throw e;
            }
        }
    }
}