using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GrpcCodeFirst.Abstractions
{

    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }
}
