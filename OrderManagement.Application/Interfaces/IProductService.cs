using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductsAsync(int pageIndex, int pageSize);
    }
}
