using Front_end.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_end.Server.Controllers
{
    public class CarroController : Controller
    {
        Uri baseaddress = new Uri("https://localhost:44364/api");
        private readonly HttpClient _client;

        public CarroController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseaddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CarroViewModel> carrolista = new List<CarroViewModel>();

            try
            {
                HttpResponseMessage response = await _client.GetAsync("/carro/Get");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    carrolista = JsonConvert.DeserializeObject<List<CarroViewModel>>(data);
                }
                else
                {
                    // Log the error or handle it as needed
                    ModelState.AddModelError(string.Empty, "Erro ao obter a lista de carros");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                ModelState.AddModelError(string.Empty, "Erro ao obter a lista de carros: " + ex.Message);
            }

            return View(carrolista);
        }
    }
}
