using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebUI.Application.Features.Products.Models;
using WebUI.Data.Abstractions.Repositories;

namespace WebUI.Application.Features.Products.Queries.GetList
{
    public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, ProductListModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductListModel> Handle(GetListProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                                                                 include: x => x.Include(p => p.ProductCategory).Include(p => p.ProductColors));

            var mappedProductListModel = _mapper.Map<ProductListModel>(products);

            return mappedProductListModel;
        }
    }
}
