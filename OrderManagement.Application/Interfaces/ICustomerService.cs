using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllAsync(int pageIndex, int pageSize);
        Task<Customer> CreateCustomerAsync(CreateCustomerDto dto);
    }
}
