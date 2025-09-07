
using Application.Dtos.NewsAnnouncement;
using Application.Models.NewsAnnouncement;
using Common.ResponseObjects;
using X.PagedList;

namespace Application.Features.CQRS.Queries.NewsAnnouncement.ListNewsAnnouncement;


public class ListNewsAnnouncementQueryResponse : Response<IPagedList<NewsAnnouncementViewModel>> {
    public ListNewsAnnouncementQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public ListNewsAnnouncementQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ListNewsAnnouncementQueryResponse(ResponseType responseType, IPagedList<NewsAnnouncementViewModel> data) : base(responseType, data) {
    }

    public ListNewsAnnouncementQueryResponse(ResponseType responseType, IPagedList<NewsAnnouncementViewModel> data, string message) : base(responseType, data, message) {
    }

    public ListNewsAnnouncementQueryResponse(ResponseType responseType, IPagedList<NewsAnnouncementViewModel> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ListNewsAnnouncementQueryResponse(ResponseType responseType, IPagedList<NewsAnnouncementViewModel> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ListNewsAnnouncementQueryResponse(ResponseType responseType, IPagedList<NewsAnnouncementViewModel> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
