using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WeatherTest.BLL.Models;
using WeatherTest.BLL.Requests;

namespace WeatherTest.Controllers
{
    [ApiController]
    [Route("api")]
    public class WeatherController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public WeatherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>Get weather in the city</summary>
        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> GetCurrentWeather(string city = "Dnipro")
        {
            string stringResult;
            try
            {
                stringResult = await OpenWeather.GetForecast(city, "weather", _configuration["MyKey"]);
            }
            catch (HttpRequestException httpRequestException)
            {
                if (httpRequestException.Message.Contains("404 (Not Found)"))
                    return NotFound(httpRequestException.Message);
                if (httpRequestException.Message.Contains("401 (Unauthorized)"))
                    return Unauthorized(httpRequestException.Message);
                return BadRequest(httpRequestException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            var forecast = JsonSerializer.Deserialize<OpenWeatherResponse>(stringResult);
            return Ok(new ForecastModel(forecast));
        }

        /// <summary>Get forecast in the city</summary>
        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> GetForecast(string city = "Dnipro")
        {
            string stringResult;
            try
            {
                stringResult = await OpenWeather.GetForecast(city, "forecast", _configuration["MyKey"]);
            }
            catch (HttpRequestException httpRequestException)
            {
                if (httpRequestException.Message.Contains("404 (Not Found)"))
                    return NotFound(httpRequestException.Message);
                if (httpRequestException.Message.Contains("401 (Unauthorized)"))
                    return Unauthorized(httpRequestException.Message);
                return BadRequest(httpRequestException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            var rawWeather = JsonSerializer.Deserialize<OpenWeatherResponses>(stringResult);
            var forecasts = rawWeather.Forecasts.Select(forecast => new ForecastModel(forecast)).ToList();
            return Ok(forecasts);
        }
    }
}