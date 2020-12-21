using OpenWeather.Library.Model;
using System.Collections.Generic;
using System.Linq;

namespace OpenWeather.API.ViewModel
{
    /// <summary>
    /// Agrupamento de histórico de temperatura de uma cidade.
    /// </summary>
    public class TemperaturaCidadeViewModel
    {
        public TemperaturaCidadeViewModel(string cidade, List<TemperaturaModel> historico)
        {
            Cidade = cidade;
            Historico = historico
                .Select(x => new TemperaturaViewModel(x))
                .OrderBy(x => x.DataHora)
                .ToList();
        }

        /// <summary>
        /// Nome da cidade
        /// </summary>
        /// <example>São Paulo</example>
        /// <example>Florianópolis</example>
        /// <example>Rio De Janeiro</example>
        public string Cidade { get; set; }

        /// <summary>
        /// Histórico de temperatura da cidade
        /// </summary>
        public List<TemperaturaViewModel> Historico { get; set; }
    }
}
