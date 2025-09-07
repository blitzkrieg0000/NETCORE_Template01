using Microsoft.AspNetCore.Http;

namespace Application.Dtos.NewsAnnouncement;


public class NewsAnnouncementUpdateDto : UpdateDto {
    public Guid? NewsAnnouncementCategoryId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public IFormFileCollection? Files { get; set; }
}
