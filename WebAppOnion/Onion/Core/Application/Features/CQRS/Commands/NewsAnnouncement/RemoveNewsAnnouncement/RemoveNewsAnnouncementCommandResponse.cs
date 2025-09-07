using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.RemoveNewsAnnouncement {
    public class RemoveNewsAnnouncementCommandResponse : Response {
        public RemoveNewsAnnouncementCommandResponse(ResponseType responseType) : base(responseType) {
        }

        public RemoveNewsAnnouncementCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
        }
    }
}