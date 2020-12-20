using OpenWeather.Library.DTO;
using System.Threading.Tasks;

namespace OpenWeather.Library.Services
{
    public interface IOpenWeatherService
    {
        Task<OpenWeatherGroupDTO> ListarDadosMeteorologicosAtuais();
    }
}
