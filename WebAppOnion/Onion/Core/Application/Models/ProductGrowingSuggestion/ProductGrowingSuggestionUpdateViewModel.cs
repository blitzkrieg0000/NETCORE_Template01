using Application.Dtos.ProductGrowingSuggestion;
using Application.Dtos.ProductGrowingSuggestionCategory;

namespace Application.Models.ProductGrowingSuggestion;

    public class ProductGrowingSuggestionUpdateViewModel
    {
        public ProductGrowingSuggestionUpdateDto? ProductGrowingSuggestionUpdateDto { get; set; }
        public List<ProductGrowingSuggestionCategoryDto>? ProductGrowingSuggestionCategoryDto { get; set; }
    }

