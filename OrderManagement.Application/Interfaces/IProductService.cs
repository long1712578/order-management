using OrderManagement.Application.DTOs;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Application.Interfaces
{
    public interface IProductService
    {
        Task<PagedResult<ProductDto>> GetProductsAsync(int pageIndex, int pageSize);
    }
}
