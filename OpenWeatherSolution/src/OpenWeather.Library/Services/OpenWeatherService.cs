using Microsoft.Extensions.Options;
using OpenWeather.Library.Model;
using OpenWeather.Library.Settings;
using System;
using System.Threading.Tasks;

namespace OpenWeather.Library.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private OpenWeatherSetting _openWeatherSetting { get; set; }

        public OpenWeatherService(IOptions<OpenWeatherSetting> openWeatherSetting)
        {
            _openWeatherSetting = openWeatherSetting.Value;
        }

        public Task<TemperaturaModel> ListarDadosMeteorologicosAtuais()
        {
            throw new NotImplementedException();
        }
    }
}
