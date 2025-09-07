using Application.Consts.Auth;
using Application.Interfaces.Service.Auth;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Api.Admin;


[ApiController]
[Route("api/[controller]", Order = 2)]
public class EndpointController : ControllerBase {

    private readonly IEndpointManagerService _endpointManagerService;

    public EndpointController(IEndpointManagerService endpointManagerService) {
        _endpointManagerService = endpointManagerService;
    }


    [HttpGet]
    public async Task<IActionResult> AssignRoleEndpoint() {
        var endpoints = await _endpointManagerService.GetUserEndpointIdentifiersByUserAsync(RoleDefaults.Admin.Id, typeof(Program));
        return Ok(endpoints);
    }
}
