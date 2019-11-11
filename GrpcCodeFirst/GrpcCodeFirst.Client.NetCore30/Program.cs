using Grpc.Net.Client;
using GrpcCodeFirst.Abstractions;
using ProtoBuf.Grpc.Client;
using System;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Client.NetCore30
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using (var channel = GrpcChannel.ForAddress("http://localhost:5001"))
            {
                var calculator = channel.CreateGrpcService<IGreeterService>();
                var result = await calculator.SayHelloAsync(new HelloRequest { Name = "Rob from netcore 3.0" });
                Console.WriteLine(result.Message);

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
}
