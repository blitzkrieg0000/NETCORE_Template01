using Application.Interfaces.Repository.NewsAnnouncement;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories.NewsAnnouncements;


public class NewsAnnouncementCommandRepository : CommandRepository<NewsAnnouncement>, INewsAnnouncementCommandRepository {
    public NewsAnnouncementCommandRepository(DefaultContext context) : base(context) {

    }
}