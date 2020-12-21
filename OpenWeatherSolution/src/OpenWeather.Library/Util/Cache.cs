using Microsoft.Extensions.Caching.Memory;
using OpenWeather.Library.Exceptions;
using System;

namespace OpenWeather.Library.Util
{
    public class Cache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public Cache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public bool ConsultarCache<T>(string chave, out T objeto)
        {
            if (string.IsNullOrWhiteSpace(chave))
            {
                throw new OpenWeatherException("Chave informada para o cache é inválida");
            }

            return _memoryCache.TryGetValue(chave, out objeto);
        }

        public void GravarCache<T>(string chave, T objeto, TimeSpan expiracao)
        {
            if (string.IsNullOrWhiteSpace(chave))
            {
                throw new OpenWeatherException("Chave informada para o cache é inválida");
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(expiracao);
            _memoryCache.Set(chave, objeto, cacheEntryOptions);
        }
    }
}
