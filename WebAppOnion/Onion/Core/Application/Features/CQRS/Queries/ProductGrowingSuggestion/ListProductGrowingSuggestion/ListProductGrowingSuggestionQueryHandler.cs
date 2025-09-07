
using Application.Dtos.ProductGrowingSuggestion;
using Application.Interfaces.Repository.ProductGrowingSuggestion;
using AutoMapper;
using Common.ResponseObjects;
using MediatR;
using X.PagedList;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.ListProductGrowingSuggestion;


public class ListProductGrowingSuggestionQueryHandler : IRequestHandler<ListProductGrowingSuggestionQueryRequest, ListProductGrowingSuggestionQueryResponse> {
    private readonly IProductGrowingSuggestionQueryRepository _productGrowingSuggestionQueryRepository;
    private readonly IMapper _mapper;

    public ListProductGrowingSuggestionQueryHandler(IProductGrowingSuggestionQueryRepository productGrowingSuggestionQueryRepository, IMapper mapper) {
        _productGrowingSuggestionQueryRepository = productGrowingSuggestionQueryRepository;
        _mapper = mapper;
    }


    public async Task<ListProductGrowingSuggestionQueryResponse> Handle(ListProductGrowingSuggestionQueryRequest request, CancellationToken cancellationToken) {
        var productGrowingSuggestions = await _productGrowingSuggestionQueryRepository.GetRangePagedListAsync(request.PaginatorModel.Page, request.PaginatorModel.Range);
        var pagedViewModel = _mapper.Map<IPagedList<ProductGrowingSuggestionDto>>(productGrowingSuggestions);
        return new(ResponseType.Success, pagedViewModel);
    }

}