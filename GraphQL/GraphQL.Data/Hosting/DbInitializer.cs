using GraphQL.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Data.Hosting
{
    public class DbInitializer
    {
        private readonly MyDbContext _myDbContext;

        public DbInitializer(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
        }

        public async Task InitializeAsync()
        {
            await _myDbContext.Database.EnsureCreatedAsync();

            var testData = CreateTestData();

            _myDbContext.Orders.AddRange(testData);
            await _myDbContext.SaveChangesAsync();
        }

        private static Order[] CreateTestData()
        {
            return new[]
                        {
                new Order
                {
                    OrderID = 1,
                    OrderRows = new List<OrderRow>
                    {
                        new OrderRow { OrderRowID = 1, ProductName = "Chair", Price = 10},
                        new OrderRow { OrderRowID = 2, ProductName = "Couch", Price = 100},
                    }
                },
                new Order
                {
                    OrderID = 2,
                    OrderRows = new List<OrderRow>
                    {
                        new OrderRow { OrderRowID = 3, ProductName = "Carpet", Price = 150},
                    }
                },
            };
        }
    }
}
