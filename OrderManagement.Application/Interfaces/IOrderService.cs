using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto dto);
        Task DeleteOrderAsync(int id);

    }
}
