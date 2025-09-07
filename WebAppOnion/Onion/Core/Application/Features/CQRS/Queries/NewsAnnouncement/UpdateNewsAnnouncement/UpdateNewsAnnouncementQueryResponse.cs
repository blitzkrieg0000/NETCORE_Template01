using Application.Dtos.NewsAnnouncement;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.NewsAnnoucement.UpdateNewsAnnouncement;


public class UpdateNewsAnnouncementQueryResponse : Response<NewsAnnouncementUpdateDto> {
    public UpdateNewsAnnouncementQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public UpdateNewsAnnouncementQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public UpdateNewsAnnouncementQueryResponse(ResponseType responseType, NewsAnnouncementUpdateDto data) : base(responseType, data) {
    }

    public UpdateNewsAnnouncementQueryResponse(ResponseType responseType, NewsAnnouncementUpdateDto data, string message) : base(responseType, data, message) {
    }

    public UpdateNewsAnnouncementQueryResponse(ResponseType responseType, NewsAnnouncementUpdateDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public UpdateNewsAnnouncementQueryResponse(ResponseType responseType, NewsAnnouncementUpdateDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public UpdateNewsAnnouncementQueryResponse(ResponseType responseType, NewsAnnouncementUpdateDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
