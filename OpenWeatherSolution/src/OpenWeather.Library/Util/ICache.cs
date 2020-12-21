using System;

namespace OpenWeather.Library.Util
{
    public interface ICache
    {
        void GravarCache<T>(string chave, T objeto, TimeSpan expiracao);
        bool ConsultarCache<T>(string chave, out T objeto);
    }
}
