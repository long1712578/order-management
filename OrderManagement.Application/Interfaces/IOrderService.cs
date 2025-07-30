using OrderManagement.Application.DTOs;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Application.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(CreateOrderDto dto);
        Task<PagedResult<OrderDto>> GetOrdersAsync(OrderFilterDto dto);
        Task<OrderDto?> GetOrderByIdAsync(int orderId);
    }
}
