using Application.Interfaces.Service.Auth;
using MediatR;

namespace Application.Features.CQRS.Commands.Auth.GoogleSignIn;


public class GoogleSignInHandler : IRequestHandler<GoogleSignInRequest, GoogleSignInResponse> {
    private readonly ICustomAuthService _customAuthService;

    public GoogleSignInHandler(ICustomAuthService customAuthService) {
        _customAuthService = customAuthService;
    }


    public async Task<GoogleSignInResponse> Handle(GoogleSignInRequest request, CancellationToken cancellationToken) {
        var response = await _customAuthService.GoogleSignInAsync();
        return new(response.ResponseType, response.Data, response.Message);
    }

}
