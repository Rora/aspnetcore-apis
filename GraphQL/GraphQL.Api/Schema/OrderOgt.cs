using GraphQL.Shared;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Schema
{
    public class OrderOgt : ObjectGraphType<Order>
    {
        public OrderOgt()
        {
            Field(o => o.OrderID);
            Field<ListGraphType<OrderRowOgt>>(
                nameof(Order.OrderRows),
                resolve: ResolveOrderRows);
        }

        private IEnumerable<OrderRow> ResolveOrderRows(ResolveFieldContext<Order> ctx)
        {
            return new List<OrderRow>();
        }

    }
}
