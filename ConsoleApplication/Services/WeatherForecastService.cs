using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Services
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CallWeatherForecastAPIAsync()
        {
            const string apiUrl = "http://localhost:5263/WeatherForecast";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Weather Forecast Data:\n" + content);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}
