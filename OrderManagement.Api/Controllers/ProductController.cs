using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController(IProductService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts(int pageIndex = 1, int pageSize = 10)
        {
            if (pageIndex < 1 || pageSize < 1)
                return BadRequest("Page index and page size must be greater than zero.");

            var customers = await service.GetProductsAsync(pageIndex, pageSize);

            return Ok(customers);
        }
    }
}
