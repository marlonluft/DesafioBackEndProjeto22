﻿using OpenWeather.Library.Model;
using System;
using System.Collections.Generic;

namespace OpenWeather.Library.Services
{
    public interface ITemperaturaService
    {
        void Gravar(TemperaturaModel model);
        List<TemperaturaModel> Listar(string[] cidades, DateTime dataInicio, DateTime dataFim);
    }
}
