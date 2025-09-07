using Application.Dtos.GrantSupport;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Queries.GrantSupport.UpdateGrantSupport;


public class UpdateGrantSupportQueryResponse : Response<GrantSupportUpdateDto> {
    public UpdateGrantSupportQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public UpdateGrantSupportQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public UpdateGrantSupportQueryResponse(ResponseType responseType, GrantSupportUpdateDto data) : base(responseType, data) {
    }

    public UpdateGrantSupportQueryResponse(ResponseType responseType, GrantSupportUpdateDto data, string message) : base(responseType, data, message) {
    }

    public UpdateGrantSupportQueryResponse(ResponseType responseType, GrantSupportUpdateDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public UpdateGrantSupportQueryResponse(ResponseType responseType, GrantSupportUpdateDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public UpdateGrantSupportQueryResponse(ResponseType responseType, GrantSupportUpdateDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}

