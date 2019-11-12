using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGrpcCodeFirst.Shared;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace BlazorGrpcCodeFirst.Server.Services
{
    public class GreeterService : IGreeterService
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public ValueTask<HelloReply> SayHelloAsync(HelloRequest request)
        {
            return new ValueTask<HelloReply>(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
