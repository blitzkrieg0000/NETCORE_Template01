using Application.Dtos.NewsAnnouncementCategory;

namespace Application.Dtos.NewsAnnouncement;


public class NewsAnnouncementDto : FixDto {
    public Guid? NewsAnnouncementCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }

}
