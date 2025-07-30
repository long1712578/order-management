using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetCustomersAsync(int pageIndex, int pageSize);
        Task<CustomerDto?> GetCustomerByIdAsync(int customerId);
        Task<Customer> CreateCustomerAsync(CreateCustomerDto dto);
        Task UpdateAsync(UpdateCustomerDto dto, int customerId);
        Task DeleteAsync(int customerId);
    }
}
