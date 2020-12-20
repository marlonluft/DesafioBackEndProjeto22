using OpenWeather.Library.Enumerador;
using OpenWeather.Library.Exceptions;
using System.Linq;

namespace OpenWeather.Library.Model
{
    public class TemperaturaModel
    {
        public TemperaturaModel(CidadeEnum cidade, string[] descricoes, float sensacaoTermica, int humidade, float temperatua, float temperatuaMinima, float temperatuaMaxima)
        {
            this.Cidade = cidade;
            this.Descricoes = descricoes;
            this.SensacaoTermica = sensacaoTermica;
            this.Humidade = humidade;
            this.Temperatua = temperatua;
            this.TemperatuaMaxima = temperatuaMaxima;
            this.TemperatuaMinima = temperatuaMinima;
            this.DataHora = DateTime.Now;
        }

        public CidadeEnum Cidade { get; private set; }
        public string[] Descricoes { get; private set; }
        public float SensacaoTermica { get; private set; }
        public int Humidade { get; private set; }
        public float Temperatua { get; private set; }
        public float TemperatuaMaxima { get; private set; }
        public float TemperatuaMinima { get; private set; }
        public DateTime DataHora { get; set; }

        public void Validar()
        {
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

            if (Temperatua < TemperatuaMinima )
            {
                throw new OpenWeatherException("A temperatura informada é menor que a temperatura mínima");
            }

            if (Temperatua > TemperatuaMaxima)
            {
                throw new OpenWeatherException("A temperatura informada é maior que a temperatura máxima");
            }
        }
    }
}
