using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Interfaces;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Application.Services
{
    public class ProductService(IProductRepository repository, IMapper mapper) : IProductService
    {
        public async Task<PagedResult<ProductDto>> GetProductsAsync(int pageIndex, int pageSize)
        {
            var result = await repository.GetAllAsync(pageIndex, pageSize);
            var productDtos = mapper.Map<List<ProductDto>>(result.Items);

            return new PagedResult<ProductDto>
            {
                Items = productDtos,
                TotalItems = result.TotalItems,
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        }
    }
}
