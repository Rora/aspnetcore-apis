using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GrpcCodeFirst.Abstractions
{
    [ProtoContract]
    public class CollectionResponseTestResponse
    {
        [ProtoMember(1)]
        public ICollection<CollectionResponseTestRow> Rows { get; set; }
    }
}
