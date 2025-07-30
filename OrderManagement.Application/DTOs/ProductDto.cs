namespace OrderManagement.Application.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = default!;

        public decimal Price { get; set; }
    }
}
