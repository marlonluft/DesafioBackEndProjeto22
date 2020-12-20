using OpenWeather.Library.Exceptions;
using OpenWeather.Library.Model;
using Xunit;

namespace OpenWeather.Library.Tests.Model
{
    public class TemperaturaTest
    {
        private string[] _descricoes => new string[1] { "Nublado" };

        [Fact(DisplayName = "Preencher Descrição nula")]
        [Trait("Model", "TemperaturaModel")]
        public void PreencherDescrcaioNula_DeveRetornarException()
        {
            // Arrange
            var temperatura = new TemperaturaModel("Cidade", null, 0, 0, 0, 0, 0);

            // Act & Assert
            Assert.Throws<OpenWeatherException>(() => temperatura.Validar());
        }

        [Fact(DisplayName = "Preencher Descrição sem registros")]
        [Trait("Model", "TemperaturaModel")]
        public void PreencherDescrcaioSemRegistros_DeveRetornarException()
        {
            // Arrange
            var descricoes = new string[0];

            var temperatura = new TemperaturaModel("Cidade", descricoes, 0, 0, 0, 0, 0);

            // Act & Assert
            Assert.Throws<OpenWeatherException>(() => temperatura.Validar());
        }

        [Fact(DisplayName = "Preencher Descrição vazia")]
        [Trait("Model", "TemperaturaModel")]
        public void PreencherDescrcaioVazia_DeveRetornarException()
        {
            // Arrange
            var descricoes = new string[1]
            {
                string.Empty
            };

            var temperatura = new TemperaturaModel("Cidade", descricoes, 0, 0, 0, 0, 0);

            // Act & Assert
            Assert.Throws<OpenWeatherException>(() => temperatura.Validar());
        }

        [Fact(DisplayName = "Preencher Cidade vazia")]
        [Trait("Model", "TemperaturaModel")]
        public void PreencherCidadeVazia_DeveRetornarException()
        {
            // Arrange
            var temperatura = new TemperaturaModel(string.Empty, _descricoes, 0, 0, 0, 0, 0);

            // Act & Assert
            Assert.Throws<OpenWeatherException>(() => temperatura.Validar());
        }

        [Fact(DisplayName = "Preencher Temperatura mínima maior que temperatura máxima")]
        [Trait("Model", "TemperaturaModel")]
        public void PreencherTemperaturaMinimaMaiorQueTemperaturaMaxima_DeveRetornarException()
        {
            // Arrange
            var temperatura = new TemperaturaModel("Cidade", _descricoes, 0, 0, 0, 30, 29);

            // Act & Assert
            Assert.Throws<OpenWeatherException>(() => temperatura.Validar());
        }

        [Fact(DisplayName = "Preencher Temperatura menor que temperatura mínima")]
        [Trait("Model", "TemperaturaModel")]
        public void PreencherTemperaturaMenorQueTemperaturaMinima_DeveRetornarException()
        {
            // Arrange
            var temperatura = new TemperaturaModel("Cidade", _descricoes, 0, 0, 5, 10, 30);

            // Act & Assert
            Assert.Throws<OpenWeatherException>(() => temperatura.Validar());
        }

        [Fact(DisplayName = "Preencher Temperatura maior que temperatura máxima")]
        [Trait("Model", "TemperaturaModel")]
        public void PreencherTemperaturaMaiorQueTemperaturaMaxima_DeveRetornarException()
        {
            // Arrange
            var temperatura = new TemperaturaModel("Cidade", _descricoes, 0, 0, 35, 10, 30);

            // Act & Assert
            Assert.Throws<OpenWeatherException>(() => temperatura.Validar());
        }
    }
}
