using Application.Dtos.NewsAnnouncement;
using Application.Dtos.NewsAnnouncementCategory;

namespace Application.Models.NewsAnnouncement;


public class NewsAnnouncementUpdateViewModel {
    public NewsAnnouncementUpdateDto? NewsAnnouncementUpdateDto { get; set; }
    public List<NewsAnnouncementCategoryDto>? NewsAnnouncementCategoryDto { get; set; }
}
