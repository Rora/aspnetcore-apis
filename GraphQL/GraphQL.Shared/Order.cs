using System;
using System.Collections.Generic;

namespace GraphQL.Shared
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<OrderRow> OrderRows { get; set; }
    }
}
