using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.DataModels;

namespace WebStore.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<StationaryStoreEmployee> StationaryStoreEmployees { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductStock> ProductStocks { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public DbSet<Invoice> Invoices { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<StationaryStore> StationaryStores { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja klucza głównego dla tabeli łączącej OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            // Konfiguracja relacji wiele-do-wielu między Order a Product przez OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Konfiguracja relacji Customer -> Address (BillingAddress i ShippingAddress)
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.BillingAddress)
                .WithMany()
                .HasForeignKey("BillingAddressId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.ShippingAddress)
                .WithMany()
                .HasForeignKey("ShippingAddressId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<User>("User")
                .HasValue<Supplier>("Supplier")
                .HasValue<StationaryStoreEmployee>("StationaryStoreEmployee")
                .HasValue<Customer>("Customer");
        }
    }
}