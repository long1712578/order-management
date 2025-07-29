using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = default!;

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
