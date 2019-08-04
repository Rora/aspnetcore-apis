using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace GraphQL.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Shared.Order> Orders { get; set; }
        public DbSet<Shared.OrderRow> OrderRows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Shared.Order>()
                .HasKey(o => o.OrderID);

            modelBuilder
                .Entity<Shared.OrderRow>()
                .HasKey(or => or.OrderRowID);
        }
    }
}
