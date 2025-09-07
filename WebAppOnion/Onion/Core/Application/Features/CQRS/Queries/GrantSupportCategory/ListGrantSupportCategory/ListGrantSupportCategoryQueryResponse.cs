using Application.Dtos.GrantSupportCategory;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.GrantSupportCategory.ListGrantSupportCategory;


public class ListGrantSupportCategoryQueryResponse : Response<List<GrantSupportCategoryDto>> {
    public ListGrantSupportCategoryQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public ListGrantSupportCategoryQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ListGrantSupportCategoryQueryResponse(ResponseType responseType, List<GrantSupportCategoryDto> data) : base(responseType, data) {
    }

    public ListGrantSupportCategoryQueryResponse(ResponseType responseType, List<GrantSupportCategoryDto> data, string message) : base(responseType, data, message) {
    }

    public ListGrantSupportCategoryQueryResponse(ResponseType responseType, List<GrantSupportCategoryDto> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ListGrantSupportCategoryQueryResponse(ResponseType responseType, List<GrantSupportCategoryDto> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ListGrantSupportCategoryQueryResponse(ResponseType responseType, List<GrantSupportCategoryDto> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
