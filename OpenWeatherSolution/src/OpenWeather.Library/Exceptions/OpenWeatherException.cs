using System;
using System.Runtime.Serialization;

namespace OpenWeather.Library.Exceptions
{
    public class OpenWeatherException : Exception
    {
        public OpenWeatherException()
        {
        }

        public OpenWeatherException(string message) : base(message)
        {
        }

        public OpenWeatherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OpenWeatherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
