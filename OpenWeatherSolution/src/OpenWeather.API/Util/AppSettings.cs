using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Library.Settings;

namespace OpenWeather.API.Util
{
    public static class AppSettings
    {
        public static void ConfigurarAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenWeatherSetting>(configuration.GetSection("OpenWeather"));
            services.AddOptions();
        }
    }
}
