using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.NewsAnnouncementCategory.RemoveNewsAnnouncementCategory;


public class RemoveNewsAnnouncementCategoryCommandResponse : Response {
    public RemoveNewsAnnouncementCategoryCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public RemoveNewsAnnouncementCategoryCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }
}
