using OpenWeather.Library.Constants;
using OpenWeather.Library.Model;
using OpenWeather.Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenWeather.Library.Repository
{
    public class TemperaturaRepository : ITemperaturaRepository
    {
        private readonly ICache _cache;

        public TemperaturaRepository(ICache cache)
        {
            _cache = cache;
        }

        public void Gravar(TemperaturaModel model)
        {
            var listaTemperatura = ListarTodos();

            listaTemperatura.Add(model);

            _cache.GravarCache(CacheConstant.LISTA_TEMPERATURA, listaTemperatura, TimeSpan.FromHours(1));
        }

        private List<TemperaturaModel> ListarTodos()
        {
            if (!_cache.ConsultarCache(CacheConstant.LISTA_TEMPERATURA, out List<TemperaturaModel> listaTemperatura))
            {
                listaTemperatura = new List<TemperaturaModel>();
            }

            return listaTemperatura;
        }

        public List<TemperaturaModel> Listar(string cidade, DateTime dataInicio, DateTime dataFim)
        {
            var listaTemperatura = ListarTodos()
                .Where(x =>
                    x.DataHora >= dataInicio &&
                    x.DataHora <= dataFim &&
                    Helper.CompararIgnorandoAcentos(x.Cidade, cidade))
                .ToList();

            return listaTemperatura;
        }
    }
}
