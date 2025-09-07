using Application.Dtos.ProductGrowingSuggestion;
using Application.Dtos.ProductGrowingSuggestionCategory;

namespace Application.Models.ProductGrowingSuggestion
{
    public class ProductGrowingSuggestionCreateViewModel 
    {

        public ProductGrowingSuggestionCreateDto? ProductGrowingSuggestionCreateDto { get; set; }

        public IEnumerable<ProductGrowingSuggestionCategoryDto>? ProductGrowingSuggestionCategoryDto { get; set; }
    }
}
