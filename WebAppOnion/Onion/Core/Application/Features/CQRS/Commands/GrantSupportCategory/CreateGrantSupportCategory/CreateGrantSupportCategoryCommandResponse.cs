using Application.Dtos.GrantSupportCategory;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.GrantSupportCategory.CreateGrantSupportCategory;


public class CreateGrantSupportCategoryCommandResponse : Response<GrantSupportCategoryCreateDto> {
    public CreateGrantSupportCategoryCommandResponse(ResponseType responseType) : base(responseType) {
    }

    public CreateGrantSupportCategoryCommandResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public CreateGrantSupportCategoryCommandResponse(ResponseType responseType, GrantSupportCategoryCreateDto data) : base(responseType, data) {
    }

    public CreateGrantSupportCategoryCommandResponse(ResponseType responseType, GrantSupportCategoryCreateDto data, string message) : base(responseType, data, message) {
    }

    public CreateGrantSupportCategoryCommandResponse(ResponseType responseType, GrantSupportCategoryCreateDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public CreateGrantSupportCategoryCommandResponse(ResponseType responseType, GrantSupportCategoryCreateDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public CreateGrantSupportCategoryCommandResponse(ResponseType responseType, GrantSupportCategoryCreateDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
