using DriveEasee;
using DriveEasee.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace DriveEaseTest
{
    [TestClass]
    public class UnitTest1
    {
            [TestMethod]
            public async Task TestMethod1()
            {
                // start the web api host application (server)
                var webAppFactory = new WebApplicationFactory<Program>();

                var HttpClient = webAppFactory.CreateDefaultClient();

                var response = await HttpClient.GetAsync("/api/Cliente");
                List<Cliente> clientes = await response.Content.ReadFromJsonAsync<List<Cliente>>();

                Assert.IsTrue(clientes.Exists(c => c.Nome.Contains("Pedro Pinto")));

            }
    }
}
