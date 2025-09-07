using Application.Dtos.ProductGrowingSuggestion;
using Application.Interfaces.Repository.ProductGrowingSuggestion;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.GetRangeProductGrowingSuggestion
{
    public class GetRangeProductGrowingSuggestionQueryHandler : IRequestHandler<GetRangeProductGrowingSuggestionQueryRequest, GetRangeProductGrowingSuggestionQueryResponse>

    {
        private readonly IProductGrowingSuggestionQueryRepository _productGrowingSuggestionQueryRepository;
        
        private readonly IMapper _mapper;
        public GetRangeProductGrowingSuggestionQueryHandler(IProductGrowingSuggestionQueryRepository productGrowingSuggestionQueryRepository, IMapper mapper)
        {
            _productGrowingSuggestionQueryRepository = productGrowingSuggestionQueryRepository;
            _mapper = mapper;
        }


        public async Task<GetRangeProductGrowingSuggestionQueryResponse> Handle(GetRangeProductGrowingSuggestionQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _productGrowingSuggestionQueryRepository.GetRangeAsync(request.Skip, request.Range, request.Filter);
            var mapped = _mapper.Map<List<ProductGrowingSuggestionDto>>(data);
            return new(ResponseType.Success, mapped);
        }
    }
}


