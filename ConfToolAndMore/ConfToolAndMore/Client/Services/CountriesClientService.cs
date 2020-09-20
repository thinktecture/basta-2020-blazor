using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ConfToolAndMore.Client.Services
{
    public class CountriesClientService
    {
        private HttpClient _httpClient;
        private string _baseApiUrl;

        public CountriesClientService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _baseApiUrl = Path.Combine(config["BaseApiUrl"], "countries");
        }

        public async Task<List<string>> ListCountriesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<string>>(_baseApiUrl);

            return result;
        }
    }
}
