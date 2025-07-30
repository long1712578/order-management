using OrderManagement.Domain.Entities;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> GetAllAsync(int pageNumber, int pageSize);
        Task<Product?> GetByIdAsync(int productId);
    }
}
