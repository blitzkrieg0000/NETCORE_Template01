

using Application.Dtos.NewsAnnouncementCategory;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.NewsAnnouncementCategory.CreateNewsAnnouncementCategory;


public class CreateNewsAnnouncementCategoryCommandResponse : Response<NewsAnnouncementCategoryCreateDto> {
    public CreateNewsAnnouncementCategoryCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public CreateNewsAnnouncementCategoryCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public CreateNewsAnnouncementCategoryCommandResponse(ResponseType responseType, NewsAnnouncementCategoryCreateDto data) : base(responseType, data) {
    }

    public CreateNewsAnnouncementCategoryCommandResponse(ResponseType responseType, NewsAnnouncementCategoryCreateDto data, string message) : base(responseType, data, message) {
    }

    public CreateNewsAnnouncementCategoryCommandResponse(ResponseType responseType, NewsAnnouncementCategoryCreateDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public CreateNewsAnnouncementCategoryCommandResponse(ResponseType responseType, NewsAnnouncementCategoryCreateDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public CreateNewsAnnouncementCategoryCommandResponse(ResponseType responseType, NewsAnnouncementCategoryCreateDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
