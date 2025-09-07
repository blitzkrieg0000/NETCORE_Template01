using Application.Dtos.ProductGrowingSuggestion;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.UpdateProductGrowingSuggestion
{
    public class UpdateProductGrowingSuggestionQueryResponse : Response<ProductGrowingSuggestionUpdateDto>
    {
        public UpdateProductGrowingSuggestionQueryResponse(ResponseType responseType) : base(responseType)
        {
        }


        public UpdateProductGrowingSuggestionQueryResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public UpdateProductGrowingSuggestionQueryResponse(ResponseType responseType, ProductGrowingSuggestionUpdateDto data) : base(responseType, data)
        {
        }

        public UpdateProductGrowingSuggestionQueryResponse(ResponseType responseType, ProductGrowingSuggestionUpdateDto data, string message) : base(responseType, data, message)
        {
        }

        public UpdateProductGrowingSuggestionQueryResponse(ResponseType responseType, ProductGrowingSuggestionUpdateDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData)
        {
        }

        public UpdateProductGrowingSuggestionQueryResponse(ResponseType responseType, ProductGrowingSuggestionUpdateDto data, List<CustomValidationError> errors) : base(responseType, data, errors)
        {
        }

        public UpdateProductGrowingSuggestionQueryResponse(ResponseType responseType, ProductGrowingSuggestionUpdateDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors)
        {
        }

    }
}