namespace Application.Dtos.ProductGrowingSuggestion;


public class ProductGrowingSuggestionDto : FixDto
{
    public Guid ProductGrowingSuggestionCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
}
