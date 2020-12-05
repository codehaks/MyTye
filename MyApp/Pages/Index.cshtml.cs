using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Models;

namespace MyApp
{
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