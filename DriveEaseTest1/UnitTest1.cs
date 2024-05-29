using DriveEasee.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace DriveEaseTest
{
    [TestClass]
    public class Driveease // Esta é a classe que contém os métodos de teste.
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // start the web api host application (server)
            var webAppFactory = new WebApplicationFactory<Program>();

            var HttpClient = webAppFactory.CreateDefaultClient();

            var response = await HttpClient.GetAsync("/api/Cliente");
            List<Cliente> clientes = await response.Content.ReadFromJsonAsync<List<Cliente>>();

            Assert.IsTrue(clientes.Exists(c => c.Nome.Contains("Nuno")));

        }
       
    }
}