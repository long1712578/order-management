using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomersPaging(int pageIndex = 1, int pageSize = 10) 
        {
            return Ok();
        }
    }
}
