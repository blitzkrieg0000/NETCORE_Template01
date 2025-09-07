using Application.Dtos.Auth;
using Application.Features.CQRS.Commands.Auth.ApiRefreshTokenSignIn;
using Application.Features.CQRS.Commands.Auth.ApiSignIn;
using Application.Features.CQRS.Queries.Auth.ResetPassword;
using Application.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.API.Admin;


[ApiController]
[Route("api/[controller]", Order = 2)] //! Web ile Api'ın karışmaması için öncelik sırasını azalttık. (default: 1)
public class AuthController : ControllerBase {
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator) {
        _mediator = mediator;
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> SignIn([FromBody] UserSignInDto dto) {
        var response = await _mediator.Send(new ApiSignInRequest(dto));
        return this.ResponseOkResult(response);
    }


    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> RefreshToken([FromBody] ApiRefreshTokenSignInRequest _apiRefreshTokenSignInRequest) {
        // Bazı sayfalarda kullanıcı işlemlere devam ettikçe resfresh token yenilenecek. MVC de olmaması gereken özel bir kullanım için
        var response = await _mediator.Send(_apiRefreshTokenSignInRequest);
        return this.ResponseOkResult(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordModel dto) {
        var response = await _mediator.Send(new ResetPasswordRequest(dto));
        return this.ResponseOkResult(response);
    }


}
