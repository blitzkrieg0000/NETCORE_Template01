using Application.Attributes;
using Application.Consts.Auth;
using Application.Enums;
using Application.Features.CQRS.Queries.NewsAnnouncement.GetRangeNewsAnnouncement;
using Application.Features.CQRS.Queries.NewsAnnouncementCategory.ListNewsAnnouncementCategory;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Api;


[ApiController]
[Route("api/[controller]", Order = 2)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class NewsAnnouncementCategoryController : ControllerBase {
    private readonly IMediator _mediator;

    public NewsAnnouncementCategoryController(IMediator mediator) {
        _mediator = mediator;
    }


    [HttpGet]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.APINewsAnnouncementCategory,
        ActionType = ActionType.Reading,
        Definition = "API Haber Kategorisi Listeleme Yetkisi"
    )]
    // Kategorilerin hepsini çekebiliriz çünkü bu proje için binlerce kategori olmayacak.
    public async Task<IActionResult> List() {
        var response = await _mediator.Send(new ListNewsAnnouncementCategoryQueryRequest(x => x.Active));
        return this.ResponseOkResult(response);
    }


    [HttpGet("{id}/all")]
    public async Task<IActionResult> GetNewsByCategoryId([FromRoute] Guid id, int skip, int range) {
        var getRangeNewsAnnouncementQueryRequest = new GetRangeNewsAnnouncementQueryRequest {
            Skip = skip,
            Range = range,
            Filter = x => x.NewsAnnouncementCategoryId == id && x.Active
        };
        var response = await _mediator.Send(getRangeNewsAnnouncementQueryRequest);
        return this.ResponseOkResult(response);
    }
}
