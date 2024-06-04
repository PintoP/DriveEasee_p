using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace Frontend.Controllers
{
    public class CarroController : Controller
    {
        private readonly HttpClient _client;

        public CarroController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44364/api");
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<CarroViewM> carrolista = new List<CarroViewM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/carro/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                carrolista = JsonConvert.DeserializeObject<List<CarroViewM>>(data);
            }

            return View(carrolista);
        }
    }
}
