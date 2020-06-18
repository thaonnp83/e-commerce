using System;
using System.Linq;
using ECommerce.API.Domain;

namespace ECommerce.API.Contexts
{
    public static class ECommerceInitializeData
    {
        public static void InitializeData(ECommerceContext context)
        {
            context.Database.EnsureCreated();
            if(!context.Brands.Any())
            {
                var brands = new Brand[]
                {
                    new Brand { Name = "Adidas" },
                    new Brand { Name = "Nike" },
                    new Brand { Name = "BMW" },
                    new Brand { Name = "Toyota" }
                };

                context.AddRange(brands);
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categories = new Category[]
                {
                    new Category { Name = "Car" },
                    new Category { Name = "Sport Shoes" }
                };

                context.AddRange(categories);
                context.SaveChanges();
            }

            if(!context.Products.Any())
            {
                var products = new Product[]
                {
                    new Product { Name = "Adidas Version 2020", Description = "Adidas Version 2020 - line 1", Price = 50, CategoryId = 2, BrandId = 1 },
                    new Product { Name = "Nike Version 2020", Description = "Nike Version 2020 - line 1", Price = 100, CategoryId = 2, BrandId = 2 },
                    new Product { Name = "Adidas Version 2019", Description = "Adidas Version 2019 - line 1", Price = 300, CategoryId = 2, BrandId = 1 },
                    new Product { Name = "Nike Version 2019", Description = "Nike Version 2020 - line 1", Price = 250, CategoryId = 2, BrandId = 2 },
                    new Product { Name = "BMW 2020", Description = "Adidas Version 2020 - 2019 1", Price = 10000, CategoryId = 1, BrandId = 3 },
                    new Product { Name = "BMW 2019", Description = "BMW Version 2019 - line 1", Price = 50000, CategoryId = 1, BrandId = 3 },
                    new Product { Name = "Toyota 2020", Description = "Toyota Version 2020 - line 1", Price = 40000, CategoryId = 1, BrandId = 4 },
                    new Product { Name = "Toyota 2019", Description = "Toyota Version 2019 - line 1", Price = 35000, CategoryId = 1, BrandId = 4 },
                };

                context.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
