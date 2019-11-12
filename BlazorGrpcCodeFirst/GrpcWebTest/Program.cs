using BlazorGrpcCodeFirst.Shared;
using Grpc.Core;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GrpcWebTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;

            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:5002") };
            var grpcWebCallInvoker = new GrpcWebCallInvoker(httpClient);

            var calculator = CreateGrpcService<IGreeterService>(grpcWebCallInvoker);
            var result = await calculator.SayHelloAsync(new HelloRequest { Name = "Rob from GrpcWeb" });
            Console.WriteLine(result.Message);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        public static TService CreateGrpcService<TService>(CallInvoker callInvoker) where TService : class
        {
            return ClientFactory.Default.CreateClient<TService>(callInvoker);
        }
    }
}
