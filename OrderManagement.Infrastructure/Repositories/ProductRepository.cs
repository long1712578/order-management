using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Data;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<PagedResult<Product>> GetAllAsync(int pageNumber, int pageSize)
        {

            var products = await context.Products
                        .AsNoTracking()
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
            return new PagedResult<Product>
            {
                Items = products,
                PageIndex = pageNumber,
                PageSize = pageSize,
                TotalItems = await context.Products.CountAsync()
            };
        }

        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await context.Products
                        .AsNoTracking()
                        .FirstOrDefaultAsync(c => c.ProductId == productId);
        }
    }
}
