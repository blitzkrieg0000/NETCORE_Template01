using Domain.Entities;


namespace Domain.Entities.Concrete;


public partial class NewsAnnouncementCategory : BaseEntity {
    public string? Name { get; set; }

    public virtual ICollection<NewsAnnouncement> NewsAnnouncements { get; set; }


    public NewsAnnouncementCategory() {
        NewsAnnouncements = new HashSet<NewsAnnouncement>();
    }

}

