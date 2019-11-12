using System;
using System.Runtime.Serialization;

namespace BlazorGrpcCodeFirst.Shared
{

    [DataContract]
    public class HelloReply
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}
