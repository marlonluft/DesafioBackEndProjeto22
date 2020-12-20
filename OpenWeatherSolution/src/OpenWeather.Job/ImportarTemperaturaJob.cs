using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenWeather.Library.Services;
using OpenWeather.Library.Util;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather.Job
{
    public class ImportarTemperaturaJob : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IOpenWeatherService _openWeatherService;
        private readonly ICache _cache;
        private readonly ILogger<ImportarTemperaturaJob> _logger;

        public ImportarTemperaturaJob(IOpenWeatherService openWeatherService, ICache cache, ILogger<ImportarTemperaturaJob> logger)
        {
            _openWeatherService = openWeatherService;
            _cache = cache;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer((object state) => Executar(), null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async void Executar()
        {
            var novosDadosTemperatura = await _openWeatherService.ListarDadosMeteorologicosAtuais();
        }
    }
}

