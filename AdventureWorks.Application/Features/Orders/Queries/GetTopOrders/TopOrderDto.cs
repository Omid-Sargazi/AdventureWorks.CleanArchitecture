namespace AdventureWorks.Application.Features.Orders.Queries.GetTopOrders
{
    public class TopOrderDto
    {
         public int SalesOrderID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int TotalItems { get; set; }
    }
}