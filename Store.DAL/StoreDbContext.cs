using Microsoft.EntityFrameworkCore;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DAL
{
   public class StoreDbContext : DbContext
    {
        //public StoreDbContext(DbContextOptions<StoreDbContext>options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; 
            database=StoreDB;trusted_connection=true;MultipleActiveResultSets=true");
           
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductSupplier>()
        //        .HasOne(b => b.Product).WithOne(b => b.UnitsInStock)
        //        .IsRequired();
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<RecPerson> RecPeople { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
