using Application.Interfaces.Repository.NewsAnnouncementCategory;
using Domain.Entities.Concrete;
using Persistence.Contexts;

namespace Persistence.Repositories.NewsAnnoucementCategorys;


public class NewsAnnouncementCategoryQueryRepository : QueryRepository<NewsAnnouncementCategory>, INewsAnnouncementCategoryQueryRepository {
    public NewsAnnouncementCategoryQueryRepository(DefaultContext context) : base(context) {
    
    }
}
