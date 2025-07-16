namespace AdventureWorks.Application.Features.Products.Queries.GetAllProducts
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Subcategory { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}