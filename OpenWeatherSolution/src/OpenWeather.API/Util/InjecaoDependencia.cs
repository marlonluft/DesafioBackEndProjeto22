using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Library.Services;

namespace OpenWeather.API.Util
{
    public static class InjecaoDependencia
    {
        public static void RegistrarInjecaoDependencia(this IServiceCollection services)
        {
            // Service
            services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
        }
    }
}
