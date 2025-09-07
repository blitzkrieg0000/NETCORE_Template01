using MediatR;

namespace Application.Features.CQRS.Queries.NewsAnnoucement.UpdateNewsAnnouncement;


public class UpdateNewsAnnouncementQueryRequest : IRequest<UpdateNewsAnnouncementQueryResponse> {
    public Guid Id { get; set; }

}
