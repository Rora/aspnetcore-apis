using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Blazor.Hosting;
using System.Threading.Tasks;

namespace BlazorWasmOnDocker.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = WebAssemblyHostBuilder.CreateDefault(args);

            hostBuilder.Services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                }) // from v0.6.0-preview4
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            hostBuilder.RootComponents.Add<App>("app");

            var host = hostBuilder.Build();

            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
