using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities.Concrete;


public partial class CooperativeCategory : BaseEntity {
    public CooperativeCategory() {
        Cooperatives = new HashSet<Cooperative>();
    }

    public string Name { get; set; } = null!;

    public virtual ICollection<Cooperative> Cooperatives { get; set; }
}

