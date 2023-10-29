using AutoMapper;
using MediatR;
using WebUI.Application.Features.ProductCategories.Models;
using WebUI.Data.Abstractions.Repositories;

namespace WebUI.Application.Features.ProductCategories.Queries.GetList
{
    public class GetListProductCategoryQueryHandler : IRequestHandler<GetListProductCategoryQuery, ProductCategoryListModel>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetListProductCategoryQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryListModel> Handle(GetListProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var productCategories = await _productCategoryRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            var mappedProductCategoryListModel = _mapper.Map<ProductCategoryListModel>(productCategories);

            return mappedProductCategoryListModel;
        }
    }
}
