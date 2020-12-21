using OpenWeather.Library.Exceptions;
using OpenWeather.Library.Util;
using System;
using System.Linq;

namespace OpenWeather.Library.Model
{
    public class TemperaturaModel
    {
        public TemperaturaModel(string cidade, string[] descricoes, float sensacaoTermica, int humidade, float temperatua, float temperatuaMinima, float temperatuaMaxima)
        {
            PreencherCidade(cidade);
            this.Descricoes = descricoes;
            this.SensacaoTermica = sensacaoTermica;
            this.Humidade = humidade;
            this.Temperatua = temperatua;
            this.TemperatuaMaxima = temperatuaMaxima;
            this.TemperatuaMinima = temperatuaMinima;
            this.DataHora = DateTime.Now;
        }

        public string Cidade { get; private set; }
        public string[] Descricoes { get; private set; }
        public float SensacaoTermica { get; private set; }
        public int Humidade { get; private set; }
        public float Temperatua { get; private set; }
        public float TemperatuaMaxima { get; private set; }
        public float TemperatuaMinima { get; private set; }
        public DateTime DataHora { get; set; }

        private void PreencherCidade(string cidade)
        {
            this.Cidade = string.IsNullOrWhiteSpace(cidade) ?
                cidade : Helper.NormalizarString(cidade);
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Cidade))
            {
                throw new OpenWeatherException("A cidade informada não é válida");
            }

            if (Descricoes == null || Descricoes.Length == 0)
            {
                throw new OpenWeatherException("Nenhuma descrição informada");
            }
            else if (Descricoes.Any(x => string.IsNullOrWhiteSpace(x)))
            {
                throw new OpenWeatherException("Nenhuma descrição válida informada");
            }

            if (TemperatuaMinima > TemperatuaMaxima)
            {
                throw new OpenWeatherException("A temperatura mínima informada é maior que a temperatura máxima");
            }

            if (Temperatua < TemperatuaMinima)
            {
                throw new OpenWeatherException("A temperatura informada é menor que a temperatura mínima");
            }

            if (Temperatua > TemperatuaMaxima)
            {
                throw new OpenWeatherException("A temperatura informada é maior que a temperatura máxima");
            }
        }

        public override bool Equals(object obj)
        {
            var valido = false;

            if (obj is TemperaturaModel)
            {
                var objComparar = obj as TemperaturaModel;

                valido = this.Cidade == objComparar.Cidade &&
                    this.DataHora == objComparar.DataHora &&
                    this.Humidade == objComparar.Humidade &&
                    this.SensacaoTermica == objComparar.SensacaoTermica &&
                    this.Temperatua == objComparar.Temperatua &&
                    this.TemperatuaMaxima == objComparar.TemperatuaMaxima &&
                    this.TemperatuaMinima == objComparar.TemperatuaMinima;

                if (this.Descricoes?.Length == objComparar.Descricoes?.Length)
                {
                    for (int i = 0; i < this.Descricoes?.Length; i++)
                    {
                        if (this.Descricoes[i] != objComparar.Descricoes[i])
                        {
                            valido = false;
                            break;
                        }
                    }
                }
            }

            return valido;
        }
    }
}
