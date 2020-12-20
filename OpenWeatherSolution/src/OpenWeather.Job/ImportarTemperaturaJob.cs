using Microsoft.Extensions.Hosting;
using OpenWeather.Library.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather.Job
{
    public class ImportarTemperaturaJob : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IOpenWeatherService _openWeatherService;

        public ImportarTemperaturaJob(IOpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
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

