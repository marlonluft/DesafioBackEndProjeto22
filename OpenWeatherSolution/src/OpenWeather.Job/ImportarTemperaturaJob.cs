using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OpenWeather.Library.Settings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OpenWeather.Job
{
    public class ImportarTemperaturaJob : IHostedService, IDisposable
    {
        private Timer _timer;
        private OpenWeatherSetting _openWeatherSetting { get; set; }
        public ImportarTemperaturaJob(IOptions<OpenWeatherSetting> openWeatherSetting)
        {
            _openWeatherSetting = openWeatherSetting.Value;
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

        private void Executar()
        {

        }
    }
}

