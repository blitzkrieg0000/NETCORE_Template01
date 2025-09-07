using System.Linq.Expressions;
using Application.Models.Paginator;
using MediatR;
using C = Domain.Entities.Concrete;

namespace Application.Features.CQRS.Queries.GrantSupport.ListGrantSupport;


public class ListGrantSupportQueryRequest : IRequest<ListGrantSupportQueryResponse> {
    public PaginatorModel? PaginatorModel { get; set; }
    public Expression<Func<C::GrantSupport, bool>> Filter = x => true;

    public ListGrantSupportQueryRequest(PaginatorModel? paginatorModel) {
        PaginatorModel = paginatorModel;
    }
}

