using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApplication.Services
{
    public class AuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAccessTokenAsync(string clientId, string clientSecret, Uri tokenEndpointUri)
        {
            var clientCredentials = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
        });

            var response = await _httpClient.PostAsync(tokenEndpointUri, clientCredentials);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(content);

            return tokenResponse["access_token"].ToString();
        }
    }
}
