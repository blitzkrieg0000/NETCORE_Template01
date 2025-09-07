using Application.Dtos.Token;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.Auth.GoogleSignIn;


public class GoogleSignInResponse : Response<TokenDto> {
    public GoogleSignInResponse(ResponseType responseType) : base(responseType) {
    }

    public GoogleSignInResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public GoogleSignInResponse(ResponseType responseType, TokenDto data) : base(responseType, data) {
    }

    public GoogleSignInResponse(ResponseType responseType, TokenDto data, string message) : base(responseType, data, message) {
    }

    public GoogleSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public GoogleSignInResponse(ResponseType responseType, TokenDto data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public GoogleSignInResponse(ResponseType responseType, TokenDto data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}
