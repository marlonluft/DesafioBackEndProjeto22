using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Job;

namespace OpenWeather.API.Util
{
    public static class TarefaSegundoPlano
    {
        public static void ConfigurarTarefaSegundoPlano(this IServiceCollection services)
        {
            services.AddSingleton<ImportarTemperaturaJob>();
            services.AddHostedService<ImportarTemperaturaJob>();
        }
    }
}
