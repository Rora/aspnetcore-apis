using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;

namespace BlazorGrpcCodeFirst.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .ConfigureKestrel(o =>
                {
                    o.ListenAnyIP(5001, listenOpt => listenOpt.Protocols = HttpProtocols.Http2); //http2 listener for grpc
                    o.ListenAnyIP(5002, listenOpt => listenOpt.Protocols = HttpProtocols.Http1); //use a seperate http1 listener for the grpcwebproxy & blazor
                })
                .Build();
    }
}
