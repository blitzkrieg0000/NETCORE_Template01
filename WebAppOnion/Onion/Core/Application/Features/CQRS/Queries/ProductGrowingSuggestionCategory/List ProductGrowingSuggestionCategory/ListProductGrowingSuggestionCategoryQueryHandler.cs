using Application.Dtos.ProductGrowingSuggestionCategory;
using Application.Features.CQRS.Queries.ProductGrowingSuggestionCategory.List_ProductGrowingSuggestionCategory;
using Application.Interfaces.Repository.ProductGrowingSuggestionCategory;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;


namespace Application.Features.CQRS.Queries.ProductGrowingSuggestionCategory.ListProductGrowingSuggestionCategory
{
    public class ListProductGrowingSuggestionCategoryQueryHandler : IRequestHandler<ListProductGrowingSuggestionCategoryQueryRequest, ListProductGrowingSuggestionCategoryQueryResponse>
    {

        private readonly IProductGrowingSuggestionCategoryQueryRepository _productGrowingSuggestionCategoryQueryRepository;
        private readonly IMapper _mapper;
       
        public ListProductGrowingSuggestionCategoryQueryHandler(IProductGrowingSuggestionCategoryQueryRepository productGrowingSuggestionCategoryQueryRepository, IMapper mapper)
        {
            _productGrowingSuggestionCategoryQueryRepository = productGrowingSuggestionCategoryQueryRepository;
            _mapper = mapper;
        }


        public async Task<ListProductGrowingSuggestionCategoryQueryResponse> Handle(ListProductGrowingSuggestionCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var productGrowingSuggestionCategory = await _productGrowingSuggestionCategoryQueryRepository.GetAllByFilterAsync(request.Filter);
            var data = _mapper.Map<List<ProductGrowingSuggestionCategoryDto>>(productGrowingSuggestionCategory);
            return new ListProductGrowingSuggestionCategoryQueryResponse(ResponseType.Success, data);
        }

      
    }
}
