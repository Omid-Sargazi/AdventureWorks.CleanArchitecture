namespace AdventureWorks.Domain.Entities
{
    public class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<SalesOrderDetail> OrderDetails { get; set; } = new List<SalesOrderDetail>();
    }
}