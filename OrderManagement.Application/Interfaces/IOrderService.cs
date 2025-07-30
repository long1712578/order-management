using OrderManagement.Application.DTOs;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto dto);
        Task<List<OrderDto>> GetOrdersAsync(OrderFilterDto dto);
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
    }
}
