using Application.Models.Paginator;
using MediatR;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.ListProductGrowingSuggestion;


public class ListProductGrowingSuggestionQueryRequest : IRequest<ListProductGrowingSuggestionQueryResponse> {
    public PaginatorModel PaginatorModel { get; set; }


    public ListProductGrowingSuggestionQueryRequest(PaginatorModel paginatorModel) {
        PaginatorModel = paginatorModel;
    }
}
