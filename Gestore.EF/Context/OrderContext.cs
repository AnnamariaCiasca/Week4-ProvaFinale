using Gestore.Core;
using Gestore.Core.Models;
using Gestore.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gestore.EF
{
    public class OrderContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        public OrderContext()
            : base()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {

        }

   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = GestoreDB; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
        }
    }
}