using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;

        [Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
