using System.Linq.Expressions;
using Application.Interfaces.Repository.NewsAnnouncement;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using X.PagedList;

namespace Persistence.Repositories;


public class NewsAnnouncementQueryRepository : QueryRepository<NewsAnnouncement>, INewsAnnouncementQueryRepository {
    public NewsAnnouncementQueryRepository(DefaultContext context) : base(context) {

    }


    public async Task<IPagedList<NewsAnnouncement>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<NewsAnnouncement, bool>> filter) {
        return await Table.AsNoTracking()
        .OrderBy(x => x.Id)
        .Where(filter)
        .Include(x => x.NewsAnnouncementCategory)
        .Include(x => x.File)
        .ToPagedListAsync(page, range);
    }


    public async Task<NewsAnnouncement?> GetByIdWithRelationsAsync(Guid id) {
        return await Table.AsNoTracking()
        .Where(x => x.Id == id)
        .Include(x => x.NewsAnnouncementCategory)
        .Include(x => x.File)
        .FirstOrDefaultAsync();
    }


    public async Task<List<NewsAnnouncement>> GetRangeWithRelationsAsync(int skip, int range, Expression<Func<NewsAnnouncement, bool>> filter, bool asNoTracking = true) {
        var query = Table.AsQueryable();
        if (asNoTracking) {
            query = query.AsNoTracking();
        }
        query = query
        .Include(x => x.NewsAnnouncementCategory)
        .Include(x => x.File)
        .Where(filter);
        return await query.OrderBy(x => x.Id).Skip(skip).Take(range).ToListAsync();
    }


}