using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.RemoveNewsAnnouncement;


public class RemoveNewsAnnouncementCommandRequest : IRequest<RemoveNewsAnnouncementCommandResponse> {
    public Guid Id { get; set; }
}
