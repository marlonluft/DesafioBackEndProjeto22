using OpenWeather.Library.DTO;
using OpenWeather.Library.Model;
using System.Linq;
using Xunit;

namespace OpenWeather.Library.Tests.DTO
{
    public class OpenWeatherRegistroTest
    {
        [Fact(DisplayName = "Conversão de DTO para model")]
        [Trait("DTO", "OpenWeatherRegistroDTO")]
        public void ConversaoDTO_ParaModel_DeveConverterIgual()
        {
            // Arrange
            var dto = new OpenWeatherRegistroDTO()
            {
                Clouds = new OpenWeatherCloudsDTO
                {
                    All = 79,
                },
                Coord = new OpenWeatherCoordDTO
                {
                    Lat = -22,
                    Lon = -49,
                },
                Dt = 1608509269,
                Id = 3448433,
                Main = new OpenWeatherMainDTO
                {
                    Temp = 26.11f,
                    FeelsLike = 29.2f,
                    GrndLevel = null,
                    Humidity = 79,
                    Pressure = 1013,
                    SeaLevel = null,
                    TempMax = 26.11f,
                    TempMin = 26.11f,
                },
                Name = "São Paulo",
                Sys = new OpenWeatherSysDTO
                {
                    Country = "BR",
                    Sunrise = 1608452970,
                    Sunset = 1608501488,
                    Timezone = -10800,
                },
                Visibility = 10000,
                Weather = new OpenWeatherWeatherDTO[]
                {
                    new OpenWeatherWeatherDTO{
                        Id = 803,
                        Main = "Clouds",
                        Description = "nublado",
                        Icon = "04n",
                    }
                },
                Wind = new OpenWeatherWindDTO
                {
                    Speed = 2.44f,
                    Deg = 202,
                }
            };

            var temperatura = new TemperaturaModel(
                dto.Name,
                dto.Weather?.Select(x => x.Description).ToArray(),
                dto.Main.FeelsLike,
                dto.Main.Humidity,
                dto.Main.Temp,
                dto.Main.TempMin,
                dto.Main.TempMax);

            // Act
            var dtoConvertido = dto.ToModel();
            temperatura.DataHora = dtoConvertido.DataHora;

            // Assert
            Assert.Equal(temperatura, dtoConvertido);
        }
    }
}
