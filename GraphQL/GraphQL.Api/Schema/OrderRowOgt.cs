using GraphQL.Shared;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Schema
{
    public class OrderRowOgt : ObjectGraphType<OrderRow>
    {
        public OrderRowOgt()
        {
            Field(o => o.OrderRowID);
            Field(o => o.Price);
            Field(o => o.ProductName);
        }
    }
}
