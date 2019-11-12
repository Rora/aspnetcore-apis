using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BlazorGrpcCodeFirst.Shared
{

    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    }
}
