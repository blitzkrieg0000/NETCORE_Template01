using System.Linq.Expressions;
using Application.Models.Paginator;
using MediatR;
using C = Domain.Entities.Concrete;

namespace Application.Features.CQRS.Queries.NewsAnnouncement.ListNewsAnnouncement;


public class ListNewsAnnouncementQueryRequest : IRequest<ListNewsAnnouncementQueryResponse> {
    public PaginatorModel PaginatorModel { get; set; }
    public Expression<Func<C::NewsAnnouncement, bool>> Filter = x => true;

    public ListNewsAnnouncementQueryRequest(PaginatorModel paginatorModel) {
        PaginatorModel = paginatorModel;
    }
    
}
