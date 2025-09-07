using Application.Dtos.NewsAnnouncement;
using Application.Dtos.NewsAnnouncementCategory;

namespace Application.Models.NewsAnnouncement;


public class NewsAnnouncementViewModel : NewsAnnouncementDto {
    public NewsAnnouncementCategoryDto NewsAnnouncementCategoryDto { get; set; }
}
