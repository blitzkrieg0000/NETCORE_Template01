using Application.Dtos.NewsAnnouncement;
using MediatR;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.UpdateNewsAnnouncement;


public class UpdateNewsAnnouncementCommandRequest : IRequest<UpdateNewsAnnouncementCommandResponse> {
    public NewsAnnouncementUpdateDto? NewsAnnouncementUpdateDto { get; set; }

    public UpdateNewsAnnouncementCommandRequest(NewsAnnouncementUpdateDto? newsAnnouncementUpdateDto) {
        NewsAnnouncementUpdateDto = newsAnnouncementUpdateDto;
    }
}
