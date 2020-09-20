﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ConfToolAndMore.Shared.DTO;
using Microsoft.Extensions.Configuration;

namespace ConfToolAndMore.Client.Services
{
    public class ConferencesClientService
    {
        private HttpClient _httpClient;
        private string _baseApiUrl;

        public ConferencesClientService(HttpClient httpClient, IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ConfTool.ServerAPI");
            _baseApiUrl = Path.Combine(config["BaseApiUrl"], "conferences/");
        }

        public async Task<List<ConferenceOverview>> GetConferencesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ConferenceOverview>>(_baseApiUrl);

            return result;
        }

        public async Task<ConferenceDetails> GetConferenceDetailsAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ConferenceDetails>(_baseApiUrl + id);

            return result;
        }

        public async Task<ConferenceDetails> AddConferenceAsync(ConferenceDetails conference)
        {
            var result = await (await _httpClient.PostAsJsonAsync(
                _baseApiUrl, conference)).Content.ReadFromJsonAsync<ConferenceDetails>();

            return result;
        }
    }
}
