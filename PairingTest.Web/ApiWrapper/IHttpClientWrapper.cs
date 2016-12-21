using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace PairingTest.Web.ApiWrapper
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync();
    }

    public class HttpClientWrapper : IHttpClientWrapper
    {
        public async Task<HttpResponseMessage> GetAsync()
        {
            using (var client = new HttpClient())
            {
                var requestUrl = ConfigurationManager.AppSettings.Get("QuestionnaireServiceUri");
                return await client.GetAsync(requestUrl);
            }
        }
    }
}