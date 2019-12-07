using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcCodeFirst.Abstractions;
using Microsoft.Extensions.Logging;

namespace GrpcCodeFirst
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

        public ValueTask<CollectionResponseTestResponse> CollectionResponseTestAsync(CollectionResponseTestRequest request)
        {
            //Do note that protobuf can't distinguish between an empty list and NULL since it doesn't support NULL. 
            //Sending an empty list will result in a NULL when deserializing
            return new ValueTask<CollectionResponseTestResponse>(new CollectionResponseTestResponse
            {
                Rows = new List<CollectionResponseTestRow>()
                {
                    new CollectionResponseTestRow { Name = "test" }
                }
            });
        }
    }
}
