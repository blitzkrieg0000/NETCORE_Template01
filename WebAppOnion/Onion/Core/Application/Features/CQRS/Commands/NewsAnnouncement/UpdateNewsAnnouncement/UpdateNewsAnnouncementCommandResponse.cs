using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.UpdateNewsAnnouncement;


public class UpdateNewsAnnouncementCommandResponse : Response {
    public UpdateNewsAnnouncementCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public UpdateNewsAnnouncementCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
