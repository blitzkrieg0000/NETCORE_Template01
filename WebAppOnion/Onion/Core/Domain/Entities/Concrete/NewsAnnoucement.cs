namespace Domain.Entities.Concrete;


public partial class NewsAnnouncement : BaseEntity {
    public Guid? NewsAnnouncementCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? Image { get; set; }

    public virtual NewsAnnouncementCategory? NewsAnnouncementCategory { get; set; }
    public virtual Domain.Entities.File.File? File { get; set; }
}

