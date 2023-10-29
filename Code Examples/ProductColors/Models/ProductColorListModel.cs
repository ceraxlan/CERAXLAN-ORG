using Core.Persistence.Paging;

namespace WebUI.Application.Features.ProductColors.Models
{
    public class ProductColorListModel : BasePageableModel
    {
        public IList<ProductColorListDto> Items { get; set; }
    }
}
