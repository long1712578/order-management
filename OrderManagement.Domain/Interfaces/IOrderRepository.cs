using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> AddAsync(Order order);
    }
}
