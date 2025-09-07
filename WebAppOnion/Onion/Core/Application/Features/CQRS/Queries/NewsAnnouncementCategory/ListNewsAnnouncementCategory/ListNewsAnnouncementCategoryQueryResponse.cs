using Application.Dtos.NewsAnnouncementCategory;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.NewsAnnouncementCategory.ListNewsAnnouncementCategory;


public class ListNewsAnnouncementCategoryQueryResponse : Response<List<NewsAnnouncementCategoryDto>> {
    public ListNewsAnnouncementCategoryQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public ListNewsAnnouncementCategoryQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ListNewsAnnouncementCategoryQueryResponse(ResponseType responseType, List<NewsAnnouncementCategoryDto> data) : base(responseType, data) {
    }

    public ListNewsAnnouncementCategoryQueryResponse(ResponseType responseType, List<NewsAnnouncementCategoryDto> data, string message) : base(responseType, data, message) {
    }

    public ListNewsAnnouncementCategoryQueryResponse(ResponseType responseType, List<NewsAnnouncementCategoryDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ListNewsAnnouncementCategoryQueryResponse(ResponseType responseType, List<NewsAnnouncementCategoryDto> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ListNewsAnnouncementCategoryQueryResponse(ResponseType responseType, List<NewsAnnouncementCategoryDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
