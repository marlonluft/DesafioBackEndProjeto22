using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenWeather.Library.Exceptions;
using OpenWeather.Library.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather.Job
{
    public class ImportarTemperaturaJob : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IOpenWeatherService _openWeatherService;
        private readonly ILogger<ImportarTemperaturaJob> _logger;
        private readonly ITemperaturaService _temperaturaService;

        public ImportarTemperaturaJob(IOpenWeatherService openWeatherService, ILogger<ImportarTemperaturaJob> logger, ITemperaturaService temperaturaService)
        {
            _openWeatherService = openWeatherService;
            _logger = logger;
            _temperaturaService = temperaturaService;
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

            if (novosDadosTemperatura != null)
            {
                var listaTemperaturasAtualizadas = novosDadosTemperatura.List.Select(x => x.ToModel()).ToList();

                listaTemperaturasAtualizadas.ForEach((temperatura) =>
                {
                    try
                    {
                        _temperaturaService.Gravar(temperatura);
                    }
                    catch (Exception ex)
                    {
                        var msg = ex is OpenWeatherException ? ex.Message : "Exceção não esperada durante execução de job 'ImportarTemperaturaJob'";
                        _logger.LogError(msg, ex);
                    }
                });
            }
        }
    }
}

