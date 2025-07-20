namespace AdventureWorks.Domain.Entities
{
    public class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public DateTime orderDate { get; set; }

        public ICollection<SalesOrderDetail> OrderDetails { get; set; } = new List<SalesOrderDetail>();
    }
}