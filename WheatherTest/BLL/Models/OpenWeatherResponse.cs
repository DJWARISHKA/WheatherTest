using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherTest.BLL.Models
{
    public class OpenWeatherResponses
    {
        [JsonPropertyName("list")] public List<OpenWeatherResponse> Forecasts { get; set; }
    }

    public class OpenWeatherResponse
    {
        public string Date
        {
            get
            {
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                date = date.AddSeconds(Dt).ToLocalTime();
                return $"{date:O}"; //ISO 8601
            }
        }

        [JsonPropertyName("dt")] public long Dt { get; set; }
        [JsonPropertyName("clouds")] public Clouds Clouds { get; set; }
        [JsonPropertyName("main")] public Main Main { get; set; }
        [JsonPropertyName("wind")] public Wind Wind { get; set; }
    }

    public class Clouds
    {
        [JsonPropertyName("all")] public int Cloudy { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")] public decimal WindSpeed { get; set; }
    }

    public class Main
    {
        [JsonPropertyName("temp")] public decimal Temperature { get; set; }
        [JsonPropertyName("temp_min")] public decimal TempMin { get; set; }
        [JsonPropertyName("temp_max")] public decimal TempMax { get; set; }
    }
}