using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommonContracts.People;
using Microsoft.Extensions.Logging;

namespace frontend.Services
{
    public class PeopleService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PeopleService> _logger;

        public PeopleService(HttpClient httpClient, ILogger<PeopleService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<PersonContract[]> GetPeople()
        {
            var response= await _httpClient.GetAsync("people");
            return await response.Content.ReadFromJsonAsync<PersonContract[]>();
        }

        public async Task SaveUser(string personName)
        {
            await _httpClient.PostAsJsonAsync("people", new AddPersonContract {Name = personName});
        }
    }
}