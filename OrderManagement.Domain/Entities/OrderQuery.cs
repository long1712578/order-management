namespace OrderManagement.Domain.Entities
{
    public class OrderQuery
    {
        public int? CustomerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
