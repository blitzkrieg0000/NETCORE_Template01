using Application.Interfaces.Service.NewsAnnouncement;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.RemoveNewsAnnouncement;


public class RemoveNewsAnnouncementCommandHandler : IRequestHandler<RemoveNewsAnnouncementCommandRequest, RemoveNewsAnnouncementCommandResponse> {
    private readonly INewsAnnouncementService _newsAnnouncementService;

    public RemoveNewsAnnouncementCommandHandler(INewsAnnouncementService newsAnnouncementService) {
        _newsAnnouncementService = newsAnnouncementService;
    }


    public async Task<RemoveNewsAnnouncementCommandResponse> Handle(RemoveNewsAnnouncementCommandRequest request, CancellationToken cancellationToken) {
        var response = await _newsAnnouncementService.RemoveNewsAnnouncement(request.Id);
        return new(response.ResponseType, response.Message);
    }
}
