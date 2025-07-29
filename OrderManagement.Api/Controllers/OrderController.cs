using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrdersPaging(int pageIndex = 1, int pageSize = 10)
        {
            return Ok();
        }
    }
}
