namespace AdventureWorks.Domain.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; } = string.Empty;

        //Navigation 
        public ICollection<ProductSubcategory> ProductSubcategories { get; set; } = new List<ProductSubcategory>();
    }
}