namespace OrderManagement.Application.DTOs
{
    internal class OrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
