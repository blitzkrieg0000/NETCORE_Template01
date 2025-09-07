using Application.Interfaces.Service.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Api.Admin;


[ApiController]
[Route("api/[controller]")]
public class ApplicationServiceController : ControllerBase {

    private readonly IApplicationService _applicationService;

    public ApplicationServiceController(IApplicationService applicationService) {
        _applicationService = applicationService;
    }


    public IActionResult GetAuthorizedEndpoints() {
        var menuList = _applicationService.GetAuthorizedEndpoints(typeof(Program));
        return Ok(menuList);
    }




}
