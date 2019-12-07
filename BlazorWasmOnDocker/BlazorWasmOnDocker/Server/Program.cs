using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace BlazorWasmOnDocker.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            const string blazorConfigPath = @"/app/bin/Debug/netcoreapp3.1/BlazorWasmOnDocker.Client.blazor.config";
            var blazorConfig = File.ReadAllText(blazorConfigPath);
            blazorConfig = Regex.Replace(blazorConfig, @"[a-zA-Z]:\\.+?\\Client\\", "/Client/")
                .Replace('\\', '/');
            File.WriteAllText(blazorConfigPath, blazorConfig);
#endif

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
    }
}
