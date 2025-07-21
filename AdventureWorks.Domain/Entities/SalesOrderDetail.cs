namespace AdventureWorks.Domain.Entities
{
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public int ProductID { get; set; }
        public short OrderQty { get; set; }
        public Product? Product { get; set; }
        public SalesOrderHeader? SalesOrderHeader { get; set; }
    }
}