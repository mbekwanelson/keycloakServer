// See https://aka.ms/new-console-template for more information
using ConsoleApplication.Services;

Console.WriteLine("Hello, World!");
Console.WriteLine("Weather Forecast Console App Initialized.");

using var httpClient = new HttpClient();
var authenticationService = new AuthenticationService(httpClient);
var weatherForecastService = new WeatherForecastService(httpClient, authenticationService);

await weatherForecastService.CallWeatherForecastAPIAsync();