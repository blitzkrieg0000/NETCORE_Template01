using Application.Dtos.ProductGrowingSuggestion;
using Common.ResponseObjects;
using X.PagedList;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.ListProductGrowingSuggestion;


public class ListProductGrowingSuggestionQueryResponse : Response<IPagedList<ProductGrowingSuggestionDto>> {
    public ListProductGrowingSuggestionQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public ListProductGrowingSuggestionQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ListProductGrowingSuggestionQueryResponse(ResponseType responseType, IPagedList<ProductGrowingSuggestionDto> data) : base(responseType, data) {
    }

    public ListProductGrowingSuggestionQueryResponse(ResponseType responseType, IPagedList<ProductGrowingSuggestionDto> data, string message) : base(responseType, data, message) {
    }

    public ListProductGrowingSuggestionQueryResponse(ResponseType responseType, IPagedList<ProductGrowingSuggestionDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ListProductGrowingSuggestionQueryResponse(ResponseType responseType, IPagedList<ProductGrowingSuggestionDto> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ListProductGrowingSuggestionQueryResponse(ResponseType responseType, IPagedList<ProductGrowingSuggestionDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}