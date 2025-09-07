using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities.Concrete;


public partial class GrantSupportCategory : BaseEntity {
    public GrantSupportCategory() {
        GrantSupports = new HashSet<GrantSupport>();
    }

    public string? Name { get; set; } = null!;

    public virtual ICollection<GrantSupport> GrantSupports { get; set; }
}

