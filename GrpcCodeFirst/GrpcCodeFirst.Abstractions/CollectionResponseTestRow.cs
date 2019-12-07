using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GrpcCodeFirst.Abstractions
{
    [ProtoContract]
    public class CollectionResponseTestRow
    {
        [ProtoMember(1)]
        public string Name { get; set; }
    }
}
