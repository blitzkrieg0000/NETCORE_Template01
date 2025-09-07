using Application.Interfaces.Repository.NewsAnnouncementCategory;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories.NewsAnnouncementCategorys;


public class NewsAnnouncementCategoryCommandRepository : CommandRepository<NewsAnnouncementCategory>, INewsAnnouncementCategoryCommandRepository {
    public NewsAnnouncementCategoryCommandRepository(DefaultContext context) : base(context) {

    }
}
