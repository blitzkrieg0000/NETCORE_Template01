using Application.Interfaces.Service.NewsAnnouncement;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.UpdateNewsAnnouncement;


public class UpdateNewsAnnouncementCommandHandler : IRequestHandler<UpdateNewsAnnouncementCommandRequest, UpdateNewsAnnouncementCommandResponse> {
    private readonly INewsAnnouncementService _newsAnnouncementService;

    public UpdateNewsAnnouncementCommandHandler(INewsAnnouncementService newsAnnouncementService) {
        _newsAnnouncementService = newsAnnouncementService;
    }


    public async Task<UpdateNewsAnnouncementCommandResponse> Handle(UpdateNewsAnnouncementCommandRequest request, CancellationToken cancellationToken) {
        var response = await _newsAnnouncementService.UpdateNewsAnnouncementAsync(request.NewsAnnouncementUpdateDto);
        return new(response.ResponseType, response.Message);
    }
}
