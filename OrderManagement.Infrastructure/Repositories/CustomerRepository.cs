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

        public async Task DeleteAsync(Customer customer)
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await context.Customers
                        .AsNoTracking()
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            return await context.Customers
                        .AsNoTracking()
                        .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task UpdateAsync(Customer customer)
        {
            context.Customers.Update(customer);
            await context.SaveChangesAsync();
        }
    }
}
