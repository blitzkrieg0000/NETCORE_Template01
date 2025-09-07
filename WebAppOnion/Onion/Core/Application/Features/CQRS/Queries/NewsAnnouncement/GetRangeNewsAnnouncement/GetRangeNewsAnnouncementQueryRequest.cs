using System.Linq.Expressions;
using Application.Features.CQRS.Queries.NewsAnnoucement.GetRangeNewsAnnouncement;
using MediatR;

namespace Application.Features.CQRS.Queries.NewsAnnouncement.GetRangeNewsAnnouncement;


public class GetRangeNewsAnnouncementQueryRequest : IRequest<GetRangeNewsAnnouncementQueryResponse> {
    public int Skip { get; set; }
    public int Range { get; set; }
    public Expression<Func<Domain.Entities.Concrete.NewsAnnouncement, bool>> Filter = x => true;
}
