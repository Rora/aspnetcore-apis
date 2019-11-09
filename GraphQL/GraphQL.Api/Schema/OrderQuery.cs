using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Schema
{
    public class OrderQuery : ObjectGraphType
    {
        public OrderQuery()
        {
            //Field<ListGraphType<MessageType>>("messages", resolve: context => chat.AllMessages.Take(100));
        }
    }
}
