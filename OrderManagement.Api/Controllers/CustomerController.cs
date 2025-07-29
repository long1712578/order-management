using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Services;
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
            
            var customers = await service.GetAllAsync(pageIndex, pageSize);

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await service.CreateCustomerAsync(dto);
            return CreatedAtAction(nameof(GetCustomer), new { id = result.CustomerId }, result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return Ok();
        }
    }
}
