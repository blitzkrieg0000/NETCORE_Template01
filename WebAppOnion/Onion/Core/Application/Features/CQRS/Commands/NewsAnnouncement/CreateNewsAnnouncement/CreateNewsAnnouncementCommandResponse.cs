using Application.Dtos.NewsAnnouncement;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.NewsAnnouncement.CreateNewsAnnouncement;


public class CreateNewsAnnouncementCommandResponse : Response<NewsAnnouncementCreateDto> {
    public CreateNewsAnnouncementCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public CreateNewsAnnouncementCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public CreateNewsAnnouncementCommandResponse(ResponseType responseType, NewsAnnouncementCreateDto data) : base(responseType, data) {
    }

    public CreateNewsAnnouncementCommandResponse(ResponseType responseType, NewsAnnouncementCreateDto data, string message) : base(responseType, data, message) {
    }

    public CreateNewsAnnouncementCommandResponse(ResponseType responseType, NewsAnnouncementCreateDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public CreateNewsAnnouncementCommandResponse(ResponseType responseType, NewsAnnouncementCreateDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public CreateNewsAnnouncementCommandResponse(ResponseType responseType, NewsAnnouncementCreateDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
