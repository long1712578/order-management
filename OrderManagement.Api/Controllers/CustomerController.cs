using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController(ICustomerService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers(int pageIndex = 1, int pageSize = 10) 
        {
            if (pageIndex < 1 || pageSize < 1)
            {
                return BadRequest("Page index and page size must be greater than zero.");
            }
            
            var customers = await service.GetCustomersAsync(pageIndex, pageSize);

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateCustomerAsync(dto);

            return CreatedAtAction(nameof(GetCustomerById), new { id = result.CustomerId }, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await service.GetCustomerByIdAsync(id);

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDto dto)
        {
            await service.UpdateCustomerAsync(dto, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await service.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}
