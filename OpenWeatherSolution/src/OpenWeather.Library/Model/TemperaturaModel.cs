using OpenWeather.Library.Exceptions;
using System.Linq;

namespace OpenWeather.Library.Model
{
    public class TemperaturaModel
    {
        public TemperaturaModel(string cidade, string[] descricoes, float sensacaoTermica, int humidade, float temperatua, float temperatuaMinima, float temperatuaMaxima)
        {
            this.Cidade = cidade;
            this.Descricoes = descricoes;
            this.SensacaoTermica = sensacaoTermica;
            this.Humidade = humidade;
            this.Temperatua = temperatua;
            this.TemperatuaMaxima = temperatuaMaxima;
            this.TemperatuaMinima = temperatuaMinima;
        }

        public string Cidade { get; private set; }
        public string[] Descricoes { get; private set; }
        public float SensacaoTermica { get; private set; }
        public int Humidade { get; private set; }
        public float Temperatua { get; private set; }
        public float TemperatuaMaxima { get; private set; }
        public float TemperatuaMinima { get; private set; }

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

            if (string.IsNullOrWhiteSpace(Cidade))
            {
                throw new OpenWeatherException("A cidade informada não é válida");
            }

            if (TemperatuaMinima > TemperatuaMaxima)
            {
                throw new OpenWeatherException("A temperatura mínima informada é maior que a temperatura máxima");
            }
        }
    }
}
