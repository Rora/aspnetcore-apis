using Grpc.Core;
using Grpc.Net.Client;
using GrpcCodeFirst.Abstractions;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.Configuration;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Client.GrpcWeb
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;

            var handler = new MyHttpMessageHandler();

            var httpClient = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:5002") };
            var grpcWebCallInvoker = new GrpcWebCallInvoker(httpClient);
            
            var calculator = CreateGrpcService<IGreeterService>(grpcWebCallInvoker);
            var result = await calculator.SayHelloAsync(new HelloRequest { Name = "Rob from GrpcWeb" });
            Console.WriteLine(result.Message);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private class MyHttpMessageHandler : HttpClientHandler
        {
            public MyHttpMessageHandler() : base()
            {
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return base.SendAsync(request, cancellationToken);
            }
        }

        public static TService CreateGrpcService<TService>(CallInvoker callInvoker) where TService : class
        {
            return (ClientFactory.Default).CreateClient<TService>(callInvoker);
        }
    }
}
