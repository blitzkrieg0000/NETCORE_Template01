using Application.Dtos.ProductGrowingSuggestionCategory;
using Common.ResponseObjects;


namespace Application.Features.CQRS.Queries.ProductGrowingSuggestionCategory.List_ProductGrowingSuggestionCategory
{
    public class ListProductGrowingSuggestionCategoryQueryResponse : Response<List<ProductGrowingSuggestionCategoryDto>>
    {
        public ListProductGrowingSuggestionCategoryQueryResponse(ResponseType responseType) : base(responseType)
        {
        }


        public ListProductGrowingSuggestionCategoryQueryResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }

        public ListProductGrowingSuggestionCategoryQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionCategoryDto> data) : base(responseType, data)
        {
        }

        public ListProductGrowingSuggestionCategoryQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionCategoryDto> data, string message) : base(responseType, data, message)
        {
        }

        public ListProductGrowingSuggestionCategoryQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionCategoryDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData)
        {
        }

        public ListProductGrowingSuggestionCategoryQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionCategoryDto> data, List<CustomValidationError> errors) : base(responseType, data, errors)
        {
        }

        public ListProductGrowingSuggestionCategoryQueryResponse(ResponseType responseType, List<ProductGrowingSuggestionCategoryDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors)
        {
        }

    }
}
