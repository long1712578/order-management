using OrderManagement.Domain.Entities;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddAsync(Order order);
        Task<PagedResult<Order>> GetFilteredOrdersAsync(OrderQuery filter);
        Task<Order?> GetByIdAsync(int orderId);
    }
}
