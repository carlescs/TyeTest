using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace frontend.Services{
    public class WeatherService{
        private HttpClient _client;

        public WeatherService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecast(){
            return await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(await _client.GetStreamAsync("weatherforecast"),new JsonSerializerOptions{
                PropertyNamingPolicy=JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive=true
            });
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}