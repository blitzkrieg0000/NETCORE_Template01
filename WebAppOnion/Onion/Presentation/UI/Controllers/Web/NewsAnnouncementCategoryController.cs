using Application.Attributes;
using Application.Consts.Auth;
using Application.Dtos.NewsAnnouncementCategory;
using Application.Enums;
using Application.Features.CQRS.Commands.NewsAnnouncementCategory.CreateNewsAnnouncementCategory;
using Application.Features.CQRS.Commands.NewsAnnouncementCategory.RemoveNewsAnnouncementCategory;
using Application.Features.CQRS.Queries.NewsAnnouncementCategory.ListNewsAnnouncementCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web;


[Authorize]
public class NewsAnnouncementCategoryController : Controller {
    private readonly IMediator _mediator;

    public NewsAnnouncementCategoryController(IMediator mediator) {
        _mediator = mediator;
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncementCategory,
        ActionType = ActionType.Reading,
        Definition = "Haber Kategorisi Listeleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncementCategory.List
    )]
    public async Task<IActionResult> List() {
        var response = await _mediator.Send(new ListNewsAnnouncementCategoryQueryRequest());
        return this.ResponseView(response);
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncementCategory,
        ActionType = ActionType.Deleting,
        Definition = "Haber Kategorisi Silme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncementCategory.Delete
    )]
    public async Task<IActionResult> Remove(RemoveNewsAnnouncementCategoryCommandRequest _removeNewsAnnouncementCategoryCommandRequest) {
        var response = await _mediator.Send(_removeNewsAnnouncementCategoryCommandRequest);
        return this.ResponseRedirectToAction(response, "List");
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncementCategory,
        ActionType = ActionType.Writing,
        Definition = "Haber Kategorisi Ekleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncementCategory.Create
    )]
    public IActionResult Create() {
        return View(new NewsAnnouncementCategoryCreateDto());
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncementCategory,
        ActionType = ActionType.Writing,
        Definition = "Haber Kategorisi Ekleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncementCategory.Create
    )]
    public async Task<IActionResult> Create(NewsAnnouncementCategoryCreateDto _newsAnnouncementCategoryCreateDto) {
        if (ModelState.IsValid) {
            var response = await _mediator.Send(new CreateNewsAnnouncementCategoryCommandRequest(_newsAnnouncementCategoryCreateDto));
            return this.ResponseRedirectToActionForValidation(response, "List", "NewsAnnouncementCategory");
        }
        return View(_newsAnnouncementCategoryCreateDto);
    }
}
