namespace AdventureWorks.Application.Features.Products.Queries.GetTopSellingProducts
{
    public class TopSellingProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = "";
        public int TotalSold { get; set; }
    }

}