using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.Services
{
    public class ProductService(IProductRepository repository, IMapper mapper) : IProductService
    {
        public async Task<List<ProductDto>> GetProductsAsync(int pageIndex, int pageSize)
        {
            var products = await repository.GetAllAsync(pageIndex, pageSize);

            return mapper.Map<List<ProductDto>>(products);
        }
    }
}
