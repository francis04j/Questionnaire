using System;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace PairingTest.Web.ApiWrapper
{
    public class QueryResultBuilder : IQueryResultBuilder
    {
        public TResult BuildQueryResult<TResult>(HttpResponseMessage httpResponseMessage) where TResult : class, new()
        {
            try
            {
                //var ser = new DataContractJsonSerializer(typeof(TResult));
               // var record = (TResult)ser.ReadObject(httpResponseMessage.Content.ReadAsStreamAsync().Result);
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