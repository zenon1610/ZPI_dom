using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.EF;
using WebStore.Model.DataModels;

namespace WebStore.Tests
{
    public static class Extensions
    {
        // Create sample data 
        public static async void SeedData(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            // other seed data ... 

            // Suppliers 
            var supplier1 = new Supplier()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Bednarski",
                UserName = "supp1@eg.eg",
                Email = "supp1@eg.eg",
                RegistrationDate = new DateTime(2010, 1, 1),
            };
            await userManager.CreateAsync(supplier1, "User1234");

            //Categories 
            var category1 = new Category()
            {
                Id = 1,
                Name = "Computers",
                Tag = "#computer"
            };
            await dbContext.AddAsync(category1);

            //Products 
            var p1 = new Product()
            {
                Id = 1,
                CategoryId = category1.Id,
                SupplierId = supplier1.Id,
                Description = "Bardzo praktyczny monitor 32 cale",
                ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 },
                Name = "Monitor Dell 32",
                Price = 1000,
                Weight = 20,
            };
            await dbContext.AddAsync(p1);

            var p2 = new Product()
            {
                Id = 2,
                CategoryId = category1.Id,
                SupplierId = supplier1.Id,
                Description = "Precyzyjna mysz do pracy",
                ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x70 },
                Name = "Mysz Logitech",
                Price = 500,
                Weight = 0.5f,
            };
            await dbContext.AddAsync(p2);

            var store1 = new StationaryStore()
            {
                Id = 1,
                Name = "Main Store",
                PhoneNumber = "123456789",
                Email = "contact@mainstore.com"
            };
            await dbContext.AddAsync(store1);

            var address1 = new Address()
            {
                Id = 1,
                Street = "Main St",
                City = "Metropolis",
                PostalCode = "12345",
                Country = "Country"
            };
            await dbContext.AddAsync(address1);

            var order1 = new Order()
            {
                Id = 1,
                CustomerId = 1,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(5),
                TotalAmount = 1500,
                TrackingNumber = 987654321
            };
            await dbContext.AddAsync(order1);

            var invoice1 = new Invoice()
            {
                Id = 1,
                InvoiceNumber = "INV-001",
                IssueDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                TotalAmount = 1500,
                TaxAmount = 300,
                OrderId = order1.Id
            };
            await dbContext.AddAsync(invoice1);

            // save changes 
            await dbContext.SaveChangesAsync();
        }
    }
}