using Microsoft.AspNetCore.Http;


namespace Application.Dtos.ProductGrowingSuggestion
{
    public class ProductGrowingSuggestionCreateDto : CreateDto
    {

        public Guid? ProductGrowingSuggestionCategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public IFormFileCollection? Files { get; set; }

    }
}
