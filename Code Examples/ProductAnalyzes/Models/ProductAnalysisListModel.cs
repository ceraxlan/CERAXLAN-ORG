namespace WebUI.Application.Features.ProductAnalyzes.Models
{
    public class ProductAnalysisListModel
    {
        public ProductAnalysisListModel()
        {
            CategoryAnalysis = new List<ProductCategoryAnalysisChartDto>();
        }
        public List<ProductCategoryAnalysisChartDto> CategoryAnalysis { get; set; }
    }
}
