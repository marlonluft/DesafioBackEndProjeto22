using OpenWeather.Library.Model;
using System;
using System.Collections.Generic;

namespace OpenWeather.Library.Services
{
    public interface ITemperaturaService
    {
        List<TemperaturaModel> Listar(string cidade, DateTime dataInicio, DateTime dataFim);
    }
}
