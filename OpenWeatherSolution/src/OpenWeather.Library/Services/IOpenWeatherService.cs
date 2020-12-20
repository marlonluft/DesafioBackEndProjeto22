using OpenWeather.Library.Model;
using System.Threading.Tasks;

namespace OpenWeather.Library.Services
{
    public interface IOpenWeatherService
    {
        Task<TemperaturaModel> ListarDadosMeteorologicosAtuais();
    }
}
