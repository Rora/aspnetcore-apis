using BlazorGrpcCodeFirst.Shared;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGrpcCodeFirst.Shared
{
    [ServiceContract(Name = nameof(IGreeterService))]
    public interface IGreeterService
    {
        ValueTask<HelloReply> SayHelloAsync(HelloRequest request);
    }
}
