using System.Net.Http;
using System.Threading.Tasks;
using Hangfire.Models;

namespace Hangfire.Sdk
{
    public class HangfireApi
    {
        private IHttpClientFactory _httpClientFactory;

        public HangfireApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task Download(VideoRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("Hangfire");
            var route = "people";
            var httpResponse = await httpClient.PostAsJsonAsync(route, request);

            httpResponse.EnsureSuccessStatusCode();

        }
    }
}