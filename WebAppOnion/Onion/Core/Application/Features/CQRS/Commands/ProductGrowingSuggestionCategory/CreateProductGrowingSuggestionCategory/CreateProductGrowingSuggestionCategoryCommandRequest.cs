
using Application.Dtos.ProductGrowingSuggestionCategory;
using MediatR;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.CreateProductGrowingSuggestionCategory
{
    public class CreateProductGrowingSuggestionCategoryCommandRequest : IRequest<CreateProductGrowingSuggestionCategoryCommandResponse>
    {
        public ProductGrowingSuggestionCategoryCreateDto ProductGrowingSuggestionCategoryCreateDto;

        public CreateProductGrowingSuggestionCategoryCommandRequest(ProductGrowingSuggestionCategoryCreateDto productGrowingSuggestionCategoryCreateDto)
        {
            ProductGrowingSuggestionCategoryCreateDto = productGrowingSuggestionCategoryCreateDto;
            ProductGrowingSuggestionCategoryCreateDto.Active = true;
        }
    }
}
