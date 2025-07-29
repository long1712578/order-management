using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.DTOs;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories
{
    public class CustomerRepository(AppDbContext context) : ICustomerRepository
    {
        public async Task<Customer> AddAsync(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            return customer;
        }

        public Task DeleteAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await context.Customers
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }

        public Task<Customer?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
