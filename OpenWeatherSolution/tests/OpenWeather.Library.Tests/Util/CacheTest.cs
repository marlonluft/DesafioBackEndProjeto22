using OpenWeather.Library.Exceptions;
using OpenWeather.Library.Util;
using System;
using Xunit;

namespace OpenWeather.Library.Tests.Util
{
    public class CacheTest
    {
        private ICache _cache;

        public CacheTest(ICache cache)
        {
            _cache = cache;
        }

        [Fact(DisplayName = "Gravação e consulta iguais")]
        [Trait("Util", "Cache")]
        public void GravacaoConsulta_DeveSerIguais()
        {
            // Arrange
            var dadosParaGuardar = "Teste de Cache";

            // Act
            _cache.GravarCache("CacheTeste", dadosParaGuardar, TimeSpan.FromMinutes(1));
            _cache.ConsultarCache("CacheTeste", out string resultado);

            // Assert
            Assert.Equal(dadosParaGuardar, resultado);
        }

        [Fact(DisplayName = "Chave de cache vazia")]
        [Trait("Util", "Cache")]
        public void ChaveCacheVazia_DeveLancarExcecao()
        {
            // Arrange & Act & Assert
            Assert.Throws<OpenWeatherException>(() => _cache.GravarCache("", "Valor", TimeSpan.FromMilliseconds(1)));
        }

        [Fact(DisplayName = "Chave de cache nula")]
        [Trait("Util", "Cache")]
        public void ChaveCacheNula_DeveLancarExcecao()
        {
            // Arrange & Act & Assert
            Assert.Throws<OpenWeatherException>(() => _cache.GravarCache(null, "Valor", TimeSpan.FromMilliseconds(1)));
        }

        [Fact(DisplayName = "Alteração de cache deve ocorrer")]
        [Trait("Util", "Cache")]
        public void AlteracaoCache_DeveOcorrer()
        {
            // Arrange
            var dadosParaGuardar = "Teste de Cache";
            var dadosParaAlterar = "111";

            // Act
            _cache.GravarCache("CacheTeste", dadosParaGuardar, TimeSpan.FromMinutes(1));
            _cache.GravarCache("CacheTeste", dadosParaAlterar, TimeSpan.FromMinutes(1));

            _cache.ConsultarCache("CacheTeste", out string resultado);

            // Assert
            Assert.Equal(dadosParaAlterar, resultado);
        }

        [Fact(DisplayName = "Consulta com chave nula")]
        [Trait("Util", "Cache")]
        public void ConsultaChaveNula_DeveLancarExcecao()
        {
            // Arrange & Act & Assert
            Assert.Throws<OpenWeatherException>(() => _cache.ConsultarCache(null, out string teste));
        }
    }
}
