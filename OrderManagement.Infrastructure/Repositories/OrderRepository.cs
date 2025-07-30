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

        public async Task<List<Order>> GetFilteredOrdersAsync(OrderQuery filter)
        {
            var query = context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.Product)
            .AsQueryable();

            if (filter.CustomerId.HasValue)
                query = query.Where(x => x.CustomerId == filter.CustomerId);

            if (filter.FromDate.HasValue)
                query = query.Where(x => x.OrderDate >= filter.FromDate.Value);

            if (filter.ToDate.HasValue)
                query = query.Where(x => x.OrderDate <= filter.ToDate.Value);

            var total = await query.CountAsync();

            return await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
        }
    }
}
