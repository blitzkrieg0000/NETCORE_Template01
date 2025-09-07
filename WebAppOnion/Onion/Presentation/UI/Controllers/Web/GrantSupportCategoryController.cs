using Application.Attributes;
using Application.Consts.Auth;
using Application.Dtos.GrantSupportCategory;
using Application.Enums;
using Application.Features.CQRS.Commands.GrantSupportCategory.CreateGrantSupportCategory;
using Application.Features.CQRS.Commands.GrantSupportCategory.RemoveGrantSupportCategory;
using Application.Features.CQRS.Queries.GrantSupportCategory.ListGrantSupportCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web;


[Authorize]
public class GrantSupportCategoryController : Controller {
    private readonly IMediator _mediator;

    public GrantSupportCategoryController(IMediator mediator) {
        _mediator = mediator;
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.GrantSupportCategory,
        ActionType = ActionType.Reading,
        Definition = "Hibe ve Destek Kategori Listeleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.GrantSupportCategory.List
    )]
    public async Task<IActionResult> List() {
        var response = await _mediator.Send(new ListGrantSupportCategoryQueryRequest());
        return this.ResponseView(response);
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.GrantSupportCategory,
        ActionType = ActionType.Deleting,
        Definition = "Hibe ve Destek Kategori Silme Yetkisi",
        Identifier = EndpointDefaults.Identifier.GrantSupportCategory.Delete
    )]
    public async Task<IActionResult> Remove(RemoveGrantSupportCategoryCommandRequest _removeGrantSupportCategoryCommandRequest) {
        var response = await _mediator.Send(_removeGrantSupportCategoryCommandRequest);
        return this.ResponseRedirectToAction(response, "List");
    }


    public IActionResult Create() {
        return View(new GrantSupportCategoryCreateDto());
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.GrantSupportCategory,
        ActionType = ActionType.Writing,
        Definition = "Hibe ve Destek Kategori Ekleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.GrantSupportCategory.Create
    )]
    [HttpPost]
    public async Task<IActionResult> Create(GrantSupportCategoryCreateDto _grantSupportCategoryCreateDto) {
        if (ModelState.IsValid) {
            var response = await _mediator.Send(new CreateGrantSupportCategoryCommandRequest(_grantSupportCategoryCreateDto));
            return this.ResponseRedirectToActionForValidation(response, "List", "GrantSupportCategory");
        }
        return View(_grantSupportCategoryCreateDto);
    }
}
