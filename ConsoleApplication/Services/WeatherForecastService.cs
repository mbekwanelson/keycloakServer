using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Services
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationService _authenticationService;

        public WeatherForecastService(HttpClient httpClient, AuthenticationService authenticationService)
        {
            _httpClient = httpClient;
            _authenticationService = authenticationService;
        }

        public async Task CallWeatherForecastAPIAsync()
        {
            var accessToken = await _authenticationService.GetAccessTokenAsync(
                "console-application",
                "client-secret-from-keycloak",
                new Uri("http://localhost:8080/realms/myrealm/protocol/openid-connect/token") // Keycloak server and realm        
            );

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

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
