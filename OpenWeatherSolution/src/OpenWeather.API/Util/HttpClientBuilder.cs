using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Library.Constants;
using OpenWeather.Library.Settings;
using System;

namespace OpenWeather.API.Util
{
    public static class HttpClientBuilder
    {
        public static void ConfigurarHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var openWeatherSetting = configuration.GetSection("OpenWeather").Get<OpenWeatherSetting>();

            services.AddHttpClient(HttpClientName.OPEN_WEATHER_MAP, c =>
            {
                c.BaseAddress = new Uri(openWeatherSetting.BaseUrl);
            });
        }
    }
}
