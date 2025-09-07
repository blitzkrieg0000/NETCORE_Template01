using System.Linq.Expressions;
using Domain.Entities.Concrete;
using X.PagedList;

namespace Application.Interfaces.Repository.GrantSupports;


public interface IGrantSupportQueryRepository : IQueryRepository<GrantSupport> {

    Task<IPagedList<GrantSupport>> GetRangePagedListWithRelationsAsync(int page, int range, Expression<Func<GrantSupport, bool>> filter);
    
    Task<List<GrantSupport>> GetRangeWithRelationsAsync(int skip, int range, Expression<Func<GrantSupport, bool>> filter);

    Task<GrantSupport?> GetByIdWithRelationsAsync(Guid id);
}

