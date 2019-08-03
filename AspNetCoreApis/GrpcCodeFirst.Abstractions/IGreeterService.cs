using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GrpcCodeFirst.Abstractions
{
    [ServiceContract(Name = nameof(IGreeterService))]
    public interface IGreeterService
    {
        ValueTask<HelloReply> SayHelloAsync(HelloRequest request);
    }
}
