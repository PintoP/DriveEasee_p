using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Front_end.Shared;

namespace MyBlazorApp.Client.Services
{
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CarroViewModel>> GetWeatherForecastAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CarroViewModel>>("WeatherForecast");
        }
    }
}