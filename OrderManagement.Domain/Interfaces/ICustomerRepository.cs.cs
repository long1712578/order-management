using OrderManagement.Domain.Entities;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<PagedResult<Customer>> GetAllAsync(int pageNumber, int pageSize);
        Task<Customer?> GetByIdAsync(int customerId);
        Task<Customer> AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}
