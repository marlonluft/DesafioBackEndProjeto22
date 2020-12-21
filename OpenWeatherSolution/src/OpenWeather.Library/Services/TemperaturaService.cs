using OpenWeather.Library.Exceptions;
using OpenWeather.Library.Model;
using OpenWeather.Library.Repository;
using System;
using System.Collections.Generic;

namespace OpenWeather.Library.Services
{
    public class TemperaturaService : ITemperaturaService
    {

        private readonly ITemperaturaRepository _temperaturaRepository;


        public TemperaturaService(ITemperaturaRepository temperaturaRepository)
        {
            _temperaturaRepository = temperaturaRepository;
        }

        public void Gravar(TemperaturaModel model)
        {
            if (model == null)
            {
                throw new OpenWeatherException("Objeto de temperatura está nulo para gravação");
            }

            model.Validar();

            _temperaturaRepository.Gravar(model);
        }

        public List<TemperaturaModel> Listar(string[] cidades, DateTime dataInicio, DateTime dataFim)
        {
            return _temperaturaRepository.Listar(cidades, dataInicio, dataFim);
        }
    }
}
