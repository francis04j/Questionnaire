using System.Net.Http;

namespace PairingTest.Web.ApiWrapper
{
    public interface IQueryResultBuilder
    {
        TResult BuildQueryResult<TResult>(HttpResponseMessage httpResponseMessage) where TResult : class, new();
    }
}