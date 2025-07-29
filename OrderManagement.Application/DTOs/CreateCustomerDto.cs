using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Application.DTOs
{
    public class CreateCustomerDto
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; } = default!;

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = default!;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}
