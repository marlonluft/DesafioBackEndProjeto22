using System;
using System.Globalization;
using System.Text;

namespace OpenWeather.Library.Util
{
    public class Helper
    {
        public static string NormalizarString(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return valor;
            }

            return CultureInfo.CreateSpecificCulture("pt-BR").TextInfo.ToTitleCase(valor.Trim());
        }

        public static bool CompararIgnorandoAcentos(string texto1, string texto2)
        {
            return string.Compare(
              RemoverAcentos(texto1), RemoverAcentos(texto2), StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        private static string RemoverAcentos(string texto)
        {
            Encoding destEncoding = Encoding.GetEncoding("iso-8859-8");

            return destEncoding.GetString(
              Encoding.Convert(Encoding.UTF8, destEncoding, Encoding.UTF8.GetBytes(texto)));
        }
    }
}
