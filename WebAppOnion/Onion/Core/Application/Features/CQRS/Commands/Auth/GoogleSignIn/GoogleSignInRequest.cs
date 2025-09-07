using MediatR;

namespace Application.Features.CQRS.Commands.Auth.GoogleSignIn;


public class GoogleSignInRequest : IRequest<GoogleSignInResponse> {
}
