
using Application.Features.CQRS.Queries.GrantSupport.GetRangeGrantSupport;
using Application.Models.Search;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Api;


[ApiController]
[Route("api/[controller]", Order = 2)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GrantSupportController : ControllerBase {
    private readonly IMediator _mediator;

    public GrantSupportController(IMediator mediator) {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetRangeGrantSupportQueryRequest request, [FromQuery] SearchModel search) {

        //Search Filter
        if (ModelState.IsValid && !string.IsNullOrEmpty(search.Query)) {
            request.Filter = x => x.Title.Contains(search.Query) && x.Active == true;
        }

        var response = await _mediator.Send(request);

        return this.ResponseOkResult(response);
    }

}