using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetOrders(int pageIndex = 1, int pageSize = 10)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderId = await service.CreateOrderAsync(dto);

            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerDto>> GetOrderById(int id)
        {

            return Ok();
        }
    }
}
