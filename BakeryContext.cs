using DagnysBakeryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DagnysBakeryAPI.Data
{
    public class BakeryContext : DbContext
    {
        public BakeryContext(DbContextOptions<BakeryContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData
            (
                new Supplier
                { 
                    SupplierId = 1, 
                    Name = "Jacobs Mjöl AB", 
                    Address = "Mjölgatan 1", 
                    ContactPerson = "Jacob Ahlström", 
                    PhoneNumber = "0761123456", 
                    Email = "jacobsmjöl@gmail.com" 
                },
                new Supplier 
                { 
                    SupplierId = 2, 
                    Name = "Fabians Mjöl AB", 
                    Address = "Mjölgatan 2", 
                    ContactPerson = "Fabian Ahlström", 
                    PhoneNumber = "0761123457", 
                    Email = "fabiansmjöl@gmail.com" }
            );

            modelBuilder.Entity<Product>().HasData
            (
                new Product { ProductId = 1, Name = "Mjöl", ArticleNumber = "A001", PricePerKg = 10.5m, SupplierId = 1 },
                new Product { ProductId = 2, Name = "Mjöl", ArticleNumber = "A001", PricePerKg = 9.5m, SupplierId = 2 }
            );
        }
    }

}