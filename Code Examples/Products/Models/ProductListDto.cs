using WebUI.Application.Features.ProductColors.Models;

namespace WebUI.Application.Features.Products.Models
{
    public class ProductListDto : ProductBaseDto
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ProductColorListDto> Colors { get; set; }
    }
}
