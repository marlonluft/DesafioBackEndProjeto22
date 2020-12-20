using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenWeather.Library.Constants;
using OpenWeather.Library.DTO;
using OpenWeather.Library.Settings;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenWeather.Library.Services
{
    public class OpenWeatherService : IOpenWeatherService, IDisposable
    {
        private OpenWeatherSetting _openWeatherSetting { get; set; }
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;
        private readonly ILogger<OpenWeatherService> _logger;

        public OpenWeatherService(IOptions<OpenWeatherSetting> openWeatherSetting, IHttpClientFactory clientFactory, ILogger<OpenWeatherService> logger)
        {
            _openWeatherSetting = openWeatherSetting.Value;
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient(HttpClientName.OPEN_WEATHER_MAP);
            _logger = logger;
        }

        public async Task<OpenWeatherGroupDTO> ListarDadosMeteorologicosAtuais()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"data/2.5/group?appid={_openWeatherSetting.AppId}&units=metric&lang=pt_br&id=3448433,3451190,3463237");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<OpenWeatherGroupDTO>(responseStream);
                }
            }
            else
            {
                _logger.LogError("Falha ao realizar a listagem de dados meteorologicos");
            }

            return null;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
