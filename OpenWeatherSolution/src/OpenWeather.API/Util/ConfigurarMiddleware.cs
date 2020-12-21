using Microsoft.AspNetCore.Builder;
using OpenWeather.API.Middlewares;

namespace OpenWeather.API.Util
{
    public static class ConfigurarMiddleware
    {
        public static void RegistrarMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
