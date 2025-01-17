﻿using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Library.Repository;
using OpenWeather.Library.Services;
using OpenWeather.Library.Util;

namespace OpenWeather.API.Util
{
    public static class InjecaoDependencia
    {
        public static void RegistrarInjecaoDependencia(this IServiceCollection services)
        {
            // Util
            services.AddSingleton<ICache, Cache>();

            // Service
            services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
            services.AddSingleton<ITemperaturaService, TemperaturaService>();
            services.AddSingleton<ITemperaturaRepository, TemperaturaRepository>();
        }
    }
}
