using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Data.Repositories
{
    public class OrderRepository
    {
        private readonly MyDbContext _myDbContext;

        public OrderRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
        }

        public async Task<ICollection<Shared.Order>> GetAllAsync()
        {
            return await _myDbContext
                .Orders
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
