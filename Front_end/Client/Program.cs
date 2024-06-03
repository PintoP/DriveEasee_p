using Front_end.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Front_end.Client.Services; // Certifique-se de que o namespace está correto
using System.Net.Http;
using MyBlazorApp.Client.Services;

namespace Front_end.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Configurar HttpClient para a API
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Registrar DataService
            builder.Services.AddScoped<DataService>();

            await builder.Build().RunAsync();
        }
    }
}
