﻿namespace OrderManagement.Application.DTOs
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
