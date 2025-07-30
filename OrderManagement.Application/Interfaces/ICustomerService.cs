using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<PagedResult<CustomerDto>> GetCustomersAsync(int pageIndex, int pageSize);
        Task<CustomerDto?> GetCustomerByIdAsync(int customerId);
        Task<Customer> CreateCustomerAsync(CreateCustomerDto dto);
        Task UpdateCustomerAsync(UpdateCustomerDto dto, int customerId);
        Task DeleteCustomerAsync(int customerId);
    }
}
