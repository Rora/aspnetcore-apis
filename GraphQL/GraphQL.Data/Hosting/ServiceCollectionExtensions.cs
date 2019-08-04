using GraphQL.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Data.Hosting
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyData(this IServiceCollection services)
        {
            //Use an open connection instead of a connection string, 
            //this way we keep 1 connection open, preventing the in memory DB from being dropped
            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();

            return services
                .AddTransient<DbInitializer>()
                .AddTransient<OrderRepository>()
                .AddDbContext<MyDbContext>(o => o.UseSqlite(conn));
        }
    }
}
