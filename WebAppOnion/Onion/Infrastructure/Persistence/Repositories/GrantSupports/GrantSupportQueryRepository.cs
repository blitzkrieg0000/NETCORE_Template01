using System.Linq.Expressions;
using Application.Interfaces.Repository.GrantSupports;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using X.PagedList;

namespace Persistence.Repositories.GrantSupports;


public class GrantSupportQueryRepository : QueryRepository<GrantSupport>, IGrantSupportQueryRepository {
    public GrantSupportQueryRepository(DefaultContext context) : base(context) {

    }

    public async Task<IPagedList<GrantSupport>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<GrantSupport, bool>> filter) {
        return await Table.AsNoTracking()
        .OrderBy(x => x.Id)
        .Where(filter)
        .Include(x => x.GrantSupportCategory)
        .Include(x => x.File)
        .ToPagedListAsync(page, range);
    }


    public async Task<List<GrantSupport>> GetRangeWithRelationsAsync(int skip, int range, Expression<Func<GrantSupport, bool>> filter) {
        return await Table.AsNoTracking()
        .OrderBy(x => x.Id)
        .Where(filter)
        .Skip(skip).Take(range)
        .Include(x => x.GrantSupportCategory)
        .Include(x => x.File)
        .ToListAsync();
    }


    public async Task<GrantSupport?> GetByIdWithRelationsAsync(Guid id) {
        return await Table.AsNoTracking()
        .Where(x => x.Id == id)
        .Include(x => x.GrantSupportCategory)
        .Include(x => x.File)
        .FirstOrDefaultAsync();
    }

}

