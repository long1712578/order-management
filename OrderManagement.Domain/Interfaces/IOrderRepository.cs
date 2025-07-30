using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddAsync(Order order);
        Task<List<Order>> GetFilteredOrdersAsync(OrderQuery filter);
        Task<Order?> GetByIdAsync(int orderId);
    }
}
