using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = default!;

        [Required, MaxLength(100)]
        public string Email { get; set; } = default!;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
