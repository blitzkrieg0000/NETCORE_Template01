using System.Linq.Expressions;
using X.PagedList;
using C = Domain.Entities.Concrete;

namespace Application.Interfaces.Repository.NewsAnnouncement;


public interface INewsAnnouncementQueryRepository : IQueryRepository<C::NewsAnnouncement> {
    Task<IPagedList<C::NewsAnnouncement>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<C::NewsAnnouncement, bool>> filter);
    
    Task<C::NewsAnnouncement?> GetByIdWithRelationsAsync(Guid id);
    
    Task<List<C::NewsAnnouncement>> GetRangeWithRelationsAsync(int skip, int range, Expression<Func<C::NewsAnnouncement, bool>> filter, bool asNoTracking = true);
}
