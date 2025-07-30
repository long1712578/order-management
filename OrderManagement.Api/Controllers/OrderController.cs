using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController(IOrderService service) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderId = await service.CreateOrderAsync(dto);

            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);

        }
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] OrderFilterDto dto)
        {
            if (dto.PageNumber < 1 || dto.PageSize < 1)
            {
                return BadRequest("Page index and page size must be greater than zero.");
            }
            var orders = await service.GetOrdersAsync(dto);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var order = await service.GetOrderByIdAsync(id);
            return Ok(order);
        }
    }
}
