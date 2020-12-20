using System.Text.Json.Serialization;

namespace OpenWeather.Library.DTO
{
    public class OpenWeatherGroupDTO
    {
        [JsonPropertyName("cnt")]
        public long Cnt { get; set; }

        [JsonPropertyName("list")]
        public OpenWeatherRegistroDTO[] List { get; set; }
    }

    public class OpenWeatherRegistroDTO
    {
        [JsonPropertyName("coord")]
        public OpenWeatherCoordDTO Coord { get; set; }

        [JsonPropertyName("sys")]
        public OpenWeatherSysDTO Sys { get; set; }

        [JsonPropertyName("weather")]
        public OpenWeatherWeatherDTO[] Weather { get; set; }

        [JsonPropertyName("main")]
        public OpenWeatherMainDTO Main { get; set; }

        [JsonPropertyName("visibility")]
        public long Visibility { get; set; }

        [JsonPropertyName("wind")]
        public OpenWeatherWindDTO Wind { get; set; }

        [JsonPropertyName("clouds")]
        public OpenWeatherCloudsDTO Clouds { get; set; }

        [JsonPropertyName("dt")]
        public long Dt { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class OpenWeatherCloudsDTO
    {
        [JsonPropertyName("all")]
        public long All { get; set; }
    }

    public class OpenWeatherCoordDTO
    {
        [JsonPropertyName("lon")]
        public float Lon { get; set; }

        [JsonPropertyName("lat")]
        public float Lat { get; set; }
    }

    public class OpenWeatherMainDTO
    {
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public float TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public float TempMax { get; set; }

        [JsonPropertyName("pressure")]
        public long Pressure { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sea_level")]
        public long? SeaLevel { get; set; }

        [JsonPropertyName("grnd_level")]
        public long? GrndLevel { get; set; }
    }

    public class OpenWeatherSysDTO
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("timezone")]
        public long Timezone { get; set; }

        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
    }

    public class OpenWeatherWeatherDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }

    public class OpenWeatherWindDTO
    {
        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("deg")]
        public long Deg { get; set; }
    }
}
