using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherTest.BLL.Requests
{
    public static class OpenWeather
    {
        public static async Task<string> GetForecast(string city, string rType, string key)
        {
            using var client = new HttpClient {BaseAddress = new Uri("http://api.openweathermap.org")};
            var request = $"/data/2.5/{rType}?q={city}&lang=ru&appid={key}&units=metric";
            var response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}