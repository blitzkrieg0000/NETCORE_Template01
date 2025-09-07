using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities.Concrete;

public partial class ProductGrowingSuggestionCategory : BaseEntity {
    public ProductGrowingSuggestionCategory() {
        ProductGrowingSuggestions = new HashSet<ProductGrowingSuggestion>();
    }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProductGrowingSuggestion> ProductGrowingSuggestions { get; set; }
}

