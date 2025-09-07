
using Application.Dtos.ProductGrowingSuggestion;
using Application.Dtos.ProductGrowingSuggestionCategory;


namespace Application.Models.ProductGrowingSuggestion
{
    public class ProductGrowingSuggestionViewModel :ProductGrowingSuggestionDto
    {
        public ProductGrowingSuggestionCategoryDto? ProductGrowingSuggestionCategoryDto { get; set; }
    }
}
