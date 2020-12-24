using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommonContracts.People;

namespace frontend.Services
{
    public class PeopleService
    {
        private readonly HttpClient _httpClient;

        public PeopleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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