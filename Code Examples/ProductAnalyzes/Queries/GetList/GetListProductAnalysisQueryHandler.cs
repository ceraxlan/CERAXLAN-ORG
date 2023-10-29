using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebUI.Application.Features.ProductAnalyzes.Models;
using WebUI.Data.Abstractions.Repositories;
using WebUI.Domain.Entities;

namespace WebUI.Application.Features.ProductAnalyzes.Queries.GetList
{
    public class GetListProductAnalysisQueryHandler : IRequestHandler<GetListProductAnalysisQuery, ProductAnalysisListModel>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;


        public GetListProductAnalysisQueryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<ProductAnalysisListModel> Handle(GetListProductAnalysisQuery request, CancellationToken cancellationToken)
        {
            var analysisResponse = new ProductAnalysisListModel();

            #region Quantity
            var productCategoriesMax = await _productCategoryRepository.GetListAsync(index: 0, size: 5, include: x => x.Include(k => k.Products), orderBy: x => x.OrderByDescending(a => a.Products.Count()), enableTracking: false);
            var productCategoriesMin = await _productCategoryRepository.GetListAsync(index: 0, size: 5, include: x => x.Include(k => k.Products), orderBy: x => x.OrderBy(a => a.Products.Count()), enableTracking: false);
            var productCategoryList = new List<ProductCategory>();
            productCategoryList.AddRange(productCategoriesMax.Items);
            productCategoryList.AddRange(productCategoriesMin.Items);
            productCategoryList = productCategoryList.DistinctBy(x => x.Name).ToList();
            foreach (var item in productCategoryList)
            {
                decimal maxPrice = 0;
                decimal minPrice = 0;
                int quantity = 0;
                if (item.Products.Count != 0)
                {
                    maxPrice = item.Products.ToList().Max(x => x.Price);
                    minPrice = item.Products.ToList().Min(x => x.Price);
                    quantity = item.Products.ToList().Sum(x => x.Quantity);
                }

                analysisResponse.CategoryAnalysis.Add(new ProductCategoryAnalysisChartDto
                {
                    CategoryName = item.Name,
                    ProductCount = quantity,
                    ProductMaxPrice = maxPrice,
                    ProductMinPrice = minPrice
                });
            }

            #endregion
            return analysisResponse;
        }
    }
}
