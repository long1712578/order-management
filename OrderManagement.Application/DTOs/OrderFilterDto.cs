using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
