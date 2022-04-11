
using koton.api.Data.Models;
using Koton.api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koton.api.Data
{
   public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<KotonDBContext>();
            context.Database.Migrate();
            if (!context.Customers.Any())
            {
                var address = context.Address.Add(new Address { UserAddress = "izmir" });
                context.SaveChanges();
                context.Customers.Add(new Customer { FirstName = "Ahmet", LastName = "Demirel", UserName = "Ahmet", Password = "123", Email = "Ahmet@gmail.com", Phone = "3435465", addressid = address.Entity.Id });
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                var category = context.Categories.Add(new Category { CategoryName = "pantolon", Active = true, Description = "koton pantolon" });
                context.SaveChanges();
                var productlst = new List<Product>()
                {
                    new Product(){ProductName="Chino Pantolon",Color="siyah",Size="34",UnitPrice=120,UnitWeight=200,UnitsInStock=50,UnitsOnOrder=10,ProductDescription="Chino Pantolon Siyah",DiscountAvailable=true,ProductAvailable=true,QuantityPerUnit=4,Discount=20,CategoryId=category.Entity.Id},
                    new Product(){ProductName="Kargo Jogger Pantolon",Color="mavi",Size="36",UnitPrice=230,UnitWeight=300,UnitsInStock=70,UnitsOnOrder=5,ProductDescription="Kargo Jogger Pantolon - Haki",DiscountAvailable=true,ProductAvailable=true,QuantityPerUnit=6,Discount=30,CategoryId=category.Entity.Id}
                };
                context.Products.AddRange(productlst);
                context.SaveChanges();
            }

        }
    }
}
