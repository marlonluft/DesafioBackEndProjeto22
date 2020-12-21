using Microsoft.Extensions.DependencyInjection;
using OpenWeather.Library.Util;

namespace OpenWeather.Library.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICache, Cache>();
        }
    }
}
