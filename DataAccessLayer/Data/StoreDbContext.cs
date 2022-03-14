using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { 
        
        
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            //Configuring Foreign Key and One to May relationship between Customer and Order 

            modelBuilder.Entity<Customer>()
            .HasMany<Order>(s => s.Orders)
            .WithOne(g => g.Customer)
    .       HasForeignKey(s => s.StudentID);

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
