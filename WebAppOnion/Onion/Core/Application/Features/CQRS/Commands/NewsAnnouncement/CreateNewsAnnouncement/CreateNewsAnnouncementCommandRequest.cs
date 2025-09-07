using Application.Dtos.NewsAnnouncement;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.CreateNewsAnnouncement;


public class CreateNewsAnnouncementCommandRequest : IRequest<CreateNewsAnnouncementCommandResponse> {
    public NewsAnnouncementCreateDto? NewsAnnouncementCreateDto { get; set; }

    public CreateNewsAnnouncementCommandRequest(NewsAnnouncementCreateDto? newsAnnouncementCreateDto) {
        NewsAnnouncementCreateDto = newsAnnouncementCreateDto;
    }
}
