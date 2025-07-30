using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Application.DTOs
{
    public class OrderFilterDto
    {
        public int? CustomerId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ToDate { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

    }
}
