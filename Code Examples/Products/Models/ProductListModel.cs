using Core.Persistence.Paging;

namespace WebUI.Application.Features.Products.Models
{
    public class ProductListModel : BasePageableModel
    {
        public IList<ProductListDto> Items { get; set; }
    }
}
