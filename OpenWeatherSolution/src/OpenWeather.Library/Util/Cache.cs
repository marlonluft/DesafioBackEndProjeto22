using Microsoft.Extensions.Caching.Memory;
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
            return _memoryCache.TryGetValue(chave, out objeto);
        }

        public void GravarCache<T>(string chave, T objeto, TimeSpan expiracao)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(expiracao);
            _memoryCache.Set(chave, objeto, cacheEntryOptions);
        }
    }
}
