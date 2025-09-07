using Application.Models.GrantSupportViewModel;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.GrantSupport.GetRangeGrantSupport;


public class GetRangeGrantSupportQueryResponse : Response<List<GrantSupportViewModel>> {
    public GetRangeGrantSupportQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public GetRangeGrantSupportQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public GetRangeGrantSupportQueryResponse(ResponseType responseType, List<GrantSupportViewModel> data) : base(responseType, data) {
    }

    public GetRangeGrantSupportQueryResponse(ResponseType responseType, List<GrantSupportViewModel> data, string message) : base(responseType, data, message) {
    }

    public GetRangeGrantSupportQueryResponse(ResponseType responseType, List<GrantSupportViewModel> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public GetRangeGrantSupportQueryResponse(ResponseType responseType, List<GrantSupportViewModel> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public GetRangeGrantSupportQueryResponse(ResponseType responseType, List<GrantSupportViewModel> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}

