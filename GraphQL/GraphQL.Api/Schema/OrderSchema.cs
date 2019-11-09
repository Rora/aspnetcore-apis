using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Schema
{
    public class OrderSchema : GraphQL.Types.Schema
    {
        public OrderSchema()
        {
            Query = new OrderQuery();
        }
    }
}
