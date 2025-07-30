using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task<int> AddAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return order.OrderId;

        }
    }
}
