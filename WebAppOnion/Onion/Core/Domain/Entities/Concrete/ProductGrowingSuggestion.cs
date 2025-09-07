using Domain.Entities;

namespace Domain.Entities.Concrete;


public partial class ProductGrowingSuggestion : BaseEntity {
    public Guid? ProductGrowingSuggestionCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }

    public virtual ProductGrowingSuggestionCategory? ProductGrowingSuggestionCategory { get; set; }
}

