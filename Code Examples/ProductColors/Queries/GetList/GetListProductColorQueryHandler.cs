using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebUI.Application.Features.ProductColors.Models;
using WebUI.Data.Abstractions.Repositories;

namespace WebUI.Application.Features.ProductColors.Queries.GetList
{
    public class GetListProductColorQueryHandler : IRequestHandler<GetListProductColorQuery, ProductColorListModel>
    {
        private readonly IProductColorRepository _productColorRepository;
        private readonly IMapper _mapper;

        public GetListProductColorQueryHandler(IProductColorRepository productColorRepository, IMapper mapper)
        {
            _productColorRepository = productColorRepository;
            _mapper = mapper;
        }

        public async Task<ProductColorListModel> Handle(GetListProductColorQuery request, CancellationToken cancellationToken)
        {
            var productColors = await _productColorRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize,
                                                                           include: x => x.Include(p => p.Products));

            var mappedProductColorListModel = _mapper.Map<ProductColorListModel>(productColors);

            return mappedProductColorListModel;
        }
    }
}
