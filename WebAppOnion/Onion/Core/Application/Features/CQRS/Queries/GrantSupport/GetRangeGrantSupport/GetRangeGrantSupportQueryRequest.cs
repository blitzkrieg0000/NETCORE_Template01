using System.Linq.Expressions;
using MediatR;
using C = Domain.Entities.Concrete;

namespace Application.Features.CQRS.Queries.GrantSupport.GetRangeGrantSupport;

public class GetRangeGrantSupportQueryRequest : IRequest<GetRangeGrantSupportQueryResponse> {
    public int Skip { get; set; }
    public int Range { get; set; }
    public Expression<Func<C::GrantSupport, bool>> Filter = x => x.Active == true;
}

