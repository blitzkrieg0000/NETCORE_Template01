using Application.Dtos.ProductGrowingSuggestionCategory;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.CreateProductGrowingSuggestionCategory
{
    public class CreateProductGrowingSuggestionCategoryCommandResponse
    {
        public CreateProductGrowingSuggestionCategoryCommandResponse(ResponseType success, string v)
        {
        }

        public CreateProductGrowingSuggestionCategoryCommandResponse(ResponseType notAllowed, ProductGrowingSuggestionCategoryCreateDto productGrowingSuggestionCategoryCreateDto, string v)
        {
            NotAllowed = notAllowed;
            ProductGrowingSuggestionCategoryCreateDto = productGrowingSuggestionCategoryCreateDto;
            V = v;
        }

        public ResponseType NotAllowed { get; }
        public ProductGrowingSuggestionCategoryCreateDto ProductGrowingSuggestionCategoryCreateDto { get; }
        public string V { get; }
    }
}