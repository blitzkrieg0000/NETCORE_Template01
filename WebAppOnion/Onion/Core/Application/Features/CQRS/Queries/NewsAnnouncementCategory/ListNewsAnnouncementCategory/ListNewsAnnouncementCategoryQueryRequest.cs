using System.Linq.Expressions;
using MediatR;

namespace Application.Features.CQRS.Queries.NewsAnnouncementCategory.ListNewsAnnouncementCategory;


public class ListNewsAnnouncementCategoryQueryRequest : IRequest<ListNewsAnnouncementCategoryQueryResponse> {
    public Expression<Func<Domain.Entities.Concrete.NewsAnnouncementCategory, bool>> Filter = x => true;

    public ListNewsAnnouncementCategoryQueryRequest() {

    }

    public ListNewsAnnouncementCategoryQueryRequest(Expression<Func<Domain.Entities.Concrete.NewsAnnouncementCategory, bool>> filter) {
        Filter = filter;
    }
}

