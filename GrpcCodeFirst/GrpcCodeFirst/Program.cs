using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace GrpcCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(o =>
                    {
                        o.ListenAnyIP(5001, listenOpt => listenOpt.Protocols = HttpProtocols.Http2); //http2 listener for grpc
                        o.ListenAnyIP(5002, listenOpt => listenOpt.Protocols = HttpProtocols.Http1); //use a seperate http1 listener for the grpcwebproxy
                    });
                });
    }
}
