using System.Threading.Tasks;

namespace Hangfire.Sdk
{
    public class YoutubeApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public YoutubeApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PersonDto> Create(PersonDto person)
        {
            var httpClient = _httpClientFactory.CreateClient("PeopleApi");

            var route = "people";
            var httpResponse = await httpClient.PostAsJsonAsync(route, person);

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadFromJsonAsync<PersonDto>();
        }
	}
}