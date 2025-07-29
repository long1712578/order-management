using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductsPaging(int pageIndex = 1, int pageSize = 10)
        {
            return Ok();
        }
    }
}
