using OpenWeather.Library.Model;
using System;
using System.Collections.Generic;

namespace OpenWeather.Library.Repository
{
    public interface ITemperaturaRepository
    {
        void Gravar(TemperaturaModel model);
        List<TemperaturaModel> Listar(string cidade, DateTime dataInicio, DateTime dataFim);
    }
}
