using Application.Attributes;
using Application.Consts.Auth;
using Application.Dtos.NewsAnnouncement;
using Application.Enums;
using Application.Features.CQRS.Commands.NewsAnnouncement.CreateNewsAnnouncement;
using Application.Features.CQRS.Commands.NewsAnnouncement.RemoveNewsAnnouncement;
using Application.Features.CQRS.Commands.NewsAnnouncement.UpdateNewsAnnouncement;
using Application.Features.CQRS.Queries.NewsAnnouncement.GetRangeNewsAnnouncement;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Api;


[ApiController]
[Route("api/[controller]", Order = 2)]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class NewsAnnouncementController : ControllerBase {
    private readonly IMediator _mediator;

    public NewsAnnouncementController(IMediator mediator) {
        _mediator = mediator;
    }


    [HttpGet]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.APINewsAnnouncement,
        ActionType = ActionType.Reading,
        Definition = "API Haber Listeleme Yetkisi"
    )]
    public async Task<IActionResult> Get([FromQuery] GetRangeNewsAnnouncementQueryRequest _getRangeNewsAnnouncementQueryRequest) {
        _getRangeNewsAnnouncementQueryRequest.Filter = x => x.Active;
        var response = await _mediator.Send(_getRangeNewsAnnouncementQueryRequest);
        return this.ResponseOkResult(response);
    }


    [HttpDelete("{id}")]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.APINewsAnnouncement,
        ActionType = ActionType.Deleting,
        Definition = "API Haber Silme Yetkisi"
    )]
    public async Task<IActionResult> Remove([FromRoute] RemoveNewsAnnouncementCommandRequest _removeNewsAnnouncementCommandRequest) {
        var response = await _mediator.Send(_removeNewsAnnouncementCommandRequest);
        return this.ResponseOkResult(response);
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.APINewsAnnouncement,
        ActionType = ActionType.Writing,
        Definition = "API Haber Ekleme Yetkisi"
    )]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] NewsAnnouncementCreateDto _newsAnnouncementCreateDto) {
        _newsAnnouncementCreateDto.Files = Request.Form.Files;
        var response = await _mediator.Send(new CreateNewsAnnouncementCommandRequest(_newsAnnouncementCreateDto));
        return this.ResponseCreatedResult(response);
    }


    [HttpPut]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.APINewsAnnouncement,
        ActionType = ActionType.Updating,
        Definition = "API Haber Güncelleme Yetkisi"
    )]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromForm] NewsAnnouncementUpdateDto _newsAnnouncementUpdateDto) {
        _newsAnnouncementUpdateDto.Files = Request.Form.Files;
        var response = await _mediator.Send(new UpdateNewsAnnouncementCommandRequest(_newsAnnouncementUpdateDto));
        return this.ResponseCreatedResult(response);
    }

}
