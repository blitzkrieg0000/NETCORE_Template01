namespace Domain.Entities.Concrete;


public partial class Cooperative : BaseEntity {
    public Guid? CooperativeCategoryId { get; set; }
    public string Name { get; set; } = null!;
    public string? Location { get; set; }
    public string? Phone { get; set; }
    public string? Url { get; set; }

    public virtual CooperativeCategory? CooperativeCategory { get; set; }
}