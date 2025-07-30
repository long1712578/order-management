using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(int pageNumber, int pageSize);
    }
}
