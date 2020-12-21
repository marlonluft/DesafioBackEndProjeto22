using OpenWeather.Library.Model;
using System;

namespace OpenWeather.API.ViewModel
{
    /// <summary>
    /// Representa um registro de temperatura ocorrido
    /// </summary>
    /// <param name="model"></param>
    public class TemperaturaViewModel
    {   
        public TemperaturaViewModel(TemperaturaModel model)
        {
            Descricoes = model.Descricoes;
            SensacaoTermica = model.SensacaoTermica;
            Humidade = model.Humidade;
            Temperatua = model.Temperatua;
            TemperatuaMaxima = model.TemperatuaMaxima;
            TemperatuaMinima = model.TemperatuaMinima;
            DataHora = model.DataHora;
        }

        /// <summary>
        /// Descrições do tempo no local
        /// </summary>
        public string[] Descricoes { get; private set; }

        /// <summary>
        /// Sensação térmica em graus celsius
        /// </summary>
        public float SensacaoTermica { get; private set; }

        /// <summary>
        /// Porcentagem de humidade no ar
        /// </summary>
        public int Humidade { get; private set; }

        /// <summary>
        /// Temperatura em graus celsius
        /// </summary>
        public float Temperatua { get; private set; }

        /// <summary>
        /// Temperatura máxima prevista em graus celsius
        /// </summary>
        public float TemperatuaMaxima { get; private set; }

        /// <summary>
        /// Temperatura mínima prevista em graus celsius
        /// </summary>
        public float TemperatuaMinima { get; private set; }

        /// <summary>
        /// Data/Hora do momento da temperatura
        /// </summary>
        public DateTime DataHora { get; set; }
    }
}
