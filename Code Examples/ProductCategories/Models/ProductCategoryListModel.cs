using Core.Persistence.Paging;

namespace WebUI.Application.Features.ProductCategories.Models
{
    public class ProductCategoryListModel : BasePageableModel
    {
        public IList<ProductCategoryListDto> Items { get; set; }
    }
}
