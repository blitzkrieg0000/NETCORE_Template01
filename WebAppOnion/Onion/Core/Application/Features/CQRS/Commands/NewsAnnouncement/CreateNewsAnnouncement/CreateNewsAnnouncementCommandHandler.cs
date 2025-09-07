using Application.Interfaces.Service.NewsAnnouncement;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.CreateNewsAnnouncement;


public class CreateNewsAnnouncementCommandHandler : IRequestHandler<CreateNewsAnnouncementCommandRequest, CreateNewsAnnouncementCommandResponse> {
    private readonly INewsAnnouncementService _newsAnnouncementService;

    public CreateNewsAnnouncementCommandHandler(INewsAnnouncementService newsAnnouncementService) {
        _newsAnnouncementService = newsAnnouncementService;
    }


    public async Task<CreateNewsAnnouncementCommandResponse> Handle(CreateNewsAnnouncementCommandRequest request, CancellationToken cancellationToken) {
        var response = await _newsAnnouncementService.CreateNewsAnnouncementAsync(request.NewsAnnouncementCreateDto);
        return new(response.ResponseType, response.Message);
    }

}
