using GrpcCodeFirst.Abstractions;
using ProtoBuf.Grpc.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClientExtensions.AllowUnencryptedHttp2 = true;
            using var http = new HttpClient { BaseAddress = new Uri("http://localhost:5001") };
            var calculator = http.CreateGrpcService<IGreeterService>();
            var result = await calculator.SayHelloAsync(new HelloRequest { Name = "Rob from netcore 2.2" });
            Console.WriteLine(result.Message);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
