namespace AdventureWorks.Domain.Entities
{
    public class ProductSubcategory
    {
        public int ProductSubcategoryID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProductCategoryID { get; set; }

        //Navigation
        public ProductCategory? ProductCategory { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
     }
}