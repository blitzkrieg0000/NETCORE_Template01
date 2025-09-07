using Application.Dtos.NewsAnnouncement;
using Application.Models.NewsAnnouncement;
using Common.ResponseObjects;


namespace Application.Features.CQRS.Queries.NewsAnnoucement.GetRangeNewsAnnouncement;

public class GetRangeNewsAnnouncementQueryResponse : Response<List<NewsAnnouncementViewModel>> {
    public GetRangeNewsAnnouncementQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public GetRangeNewsAnnouncementQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public GetRangeNewsAnnouncementQueryResponse(ResponseType responseType, List<NewsAnnouncementViewModel> data) : base(responseType, data) {
    }

    public GetRangeNewsAnnouncementQueryResponse(ResponseType responseType, List<NewsAnnouncementViewModel> data, string message) : base(responseType, data, message) {
    }

    public GetRangeNewsAnnouncementQueryResponse(ResponseType responseType, List<NewsAnnouncementViewModel> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public GetRangeNewsAnnouncementQueryResponse(ResponseType responseType, List<NewsAnnouncementViewModel> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public GetRangeNewsAnnouncementQueryResponse(ResponseType responseType, List<NewsAnnouncementViewModel> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
