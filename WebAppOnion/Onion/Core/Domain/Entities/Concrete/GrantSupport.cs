using Domain.Entities;


namespace Domain.Entities.Concrete;

public partial class GrantSupport : BaseEntity {

    public Guid GrantSupportCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? Image { get; set; }

    public virtual GrantSupportCategory GrantSupportCategory { get; set; } = null!;
    public virtual Domain.Entities.File.File? File { get; set; }
}

