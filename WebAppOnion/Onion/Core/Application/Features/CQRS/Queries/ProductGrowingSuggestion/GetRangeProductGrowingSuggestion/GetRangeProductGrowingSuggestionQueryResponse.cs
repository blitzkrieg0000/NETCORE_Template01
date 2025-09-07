using Application.Dtos.ProductGrowingSuggestion;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.GetRangeProductGrowingSuggestion
{
    public class GetRangeProductGrowingSuggestionQueryResponse : Response<List<ProductGrowingSuggestionDto>> 
    {
        public GetRangeProductGrowingSuggestionQueryResponse(ResponseType responseType) : base(responseType)
        {
        }

        public GetRangeProductGrowingSuggestionQueryResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public GetRangeProductGrowingSuggestionQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionDto> data) : base(responseType, data)
        {
        }

        public GetRangeProductGrowingSuggestionQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionDto> data, string message) : base(responseType, data, message)
        {
        }

        public GetRangeProductGrowingSuggestionQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData)
        {
        }

        public GetRangeProductGrowingSuggestionQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionDto> data, List<CustomValidationError> errors) : base(responseType, data, errors)
        {
        }

        public GetRangeProductGrowingSuggestionQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors)
        {
        }

    }
}

