using Microsoft.Extensions.Options;
using OpenWeather.Library.Constants;
using OpenWeather.Library.Model;
using OpenWeather.Library.Settings;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeather.Library.Services
{
    public class OpenWeatherService : IOpenWeatherService, IDisposable
    {
        private OpenWeatherSetting _openWeatherSetting { get; set; }
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        public OpenWeatherService(IOptions<OpenWeatherSetting> openWeatherSetting, IHttpClientFactory clientFactory)
        {
            _openWeatherSetting = openWeatherSetting.Value;
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient(HttpClientName.OPEN_WEATHER_MAP);
        }

        public Task<TemperaturaModel> ListarDadosMeteorologicosAtuais()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
