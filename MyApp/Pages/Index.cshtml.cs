using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp
{
    public class WeatherClient
    {
        private readonly HttpClient _client;

        public WeatherClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ICollection<WeatherInfo>> GetWeatherInfo()
        {
            return await
                (
                  (await _client.GetAsync("https://localhost:5101/weatherforecast"))
                  .Content
                  .ReadFromJsonAsync<ICollection<WeatherInfo>>());
        }
    }
    public class IndexModel : PageModel
    {
        private readonly WeatherClient _weatherClient;

        public IndexModel(WeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }
        public ICollection<WeatherInfo> WeatherList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            WeatherList =await _weatherClient.GetWeatherInfo();
            
            return Page();
        }


    }
}