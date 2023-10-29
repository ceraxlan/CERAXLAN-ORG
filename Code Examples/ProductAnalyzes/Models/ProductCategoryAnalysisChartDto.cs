namespace WebUI.Application.Features.ProductAnalyzes.Models
{
    public class ProductCategoryAnalysisChartDto
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductMaxPrice { get; set; }
        public decimal ProductMinPrice { get; set; }
    }
}
