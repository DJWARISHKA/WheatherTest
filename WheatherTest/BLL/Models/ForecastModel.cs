namespace WeatherTest.BLL.Models
{
    public class ForecastModel
    {
        public ForecastModel(OpenWeatherResponse forecast)
        {
            Date = forecast.Date; //ISO
            Cloudy = forecast.Clouds.Cloudy; //%
            Temperature = forecast.Main.Temperature; //℃
            TempMin = forecast.Main.TempMin;
            TempMax = forecast.Main.TempMax;
            WindSpeed = forecast.Wind.WindSpeed; //m/s
        }

        public string Date { get; set; }
        public int Cloudy { get; set; }
        public decimal Temperature { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
        public decimal WindSpeed { get; set; }
    }
}