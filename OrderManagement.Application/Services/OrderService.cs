using OrderManagement.Application.Common.Exceptions;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Services
{
    public class OrderService(IOrderRepository orderRepo, IProductRepository productRepo, ICustomerRepository customerRepo) : IOrderService
    {
        public async Task<int> CreateOrderAsync(CreateOrderDto dto)
        {
            var customer = await customerRepo.GetByIdAsync(dto.CustomerId);
            if (customer == null) throw new NotFoundException("Customer not found");

            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = DateTime.Now,
            };

            decimal total = 0;
            foreach (var item in dto.Items)
            {
                var product = await productRepo.GetByIdAsync(item.ProductId);
                if (product == null) throw new NotFoundException("Product not found");

                order.OrderItems.Add(new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });

                total += product.Price * item.Quantity;
            }

            order.TotalAmount = total;

            return await orderRepo.AddAsync(order);
        }

        public Task DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
