﻿namespace OrderManagement.Application.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
