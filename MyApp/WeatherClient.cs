using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyApp.Models;

namespace MyApp
{
    public class WeatherClient
    {
        private readonly HttpClient _client;

        public WeatherClient(HttpClient client,IConfiguration configuration)
        {
            _client = client;
            Configuration = configuration;

            
        }

        public IConfiguration Configuration { get; }

        public async Task<ICollection<WeatherInfo>> GetWeatherInfo()
        {
            var weatherService = Configuration.GetServiceUri("weatherservice");

            return await
                (
                  (await _client.GetAsync(weatherService+"weatherforecast"))
                  .Content
                  .ReadFromJsonAsync<ICollection<WeatherInfo>>());
        }
    }
}