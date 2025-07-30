using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Data
{
    public static class SeedData
    {
        public static async Task SeedProductsAsync(AppDbContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Laptop", Price = 1500m },
                    new Product { Name = "Mouse", Price = 20m },
                    new Product { Name = "Keyboard", Price = 50m }
                };

                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
