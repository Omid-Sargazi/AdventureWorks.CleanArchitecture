namespace AdventureWorks.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProductNumber { get; set; } = string.Empty;
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int? ProductSubcategoryID { get; set; }
        // Navigation
         public ProductCategory? ProductSubcategory { get; set; }
    }
}