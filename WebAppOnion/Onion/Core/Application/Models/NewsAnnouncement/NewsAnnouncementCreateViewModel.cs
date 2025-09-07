using Application.Dtos.NewsAnnouncement;
using Application.Dtos.NewsAnnouncementCategory;

namespace Application.Models.NewsAnnouncement;


public class NewsAnnouncementCreateViewModel {
    public NewsAnnouncementCreateDto? NewsAnnouncementCreateDto { get; set; }
    public IEnumerable<NewsAnnouncementCategoryDto>? NewsAnnouncementCategoryDto { get; set; }
}
