using Application.Attributes;
using Application.Consts.Auth;
using Application.Dtos.GrantSupport;
using Application.Enums;
using Application.Features.CQRS.Commands.GrantSupport.CreateGrantSupport;
using Application.Features.CQRS.Commands.GrantSupport.RemoveGrantSupport;
using Application.Features.CQRS.Commands.GrantSupport.UpdateGrantSupport;
using Application.Features.CQRS.Queries.GrantSupport.ListGrantSupport;
using Application.Features.CQRS.Queries.GrantSupport.UpdateGrantSupport;
using Application.Models.Paginator;
using Application.Models.Search;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web;


[Authorize]
public class GrantSupportController : Controller {
    private readonly IMediator _mediator;

    public GrantSupportController(IMediator mediator) {
        _mediator = mediator;
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.GrantSupport,
        ActionType = ActionType.Reading,
        Definition = "Hibe ve Destek Listeleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.GrantSupport.List
    )]
    public async Task<IActionResult> List(PaginatorModel model, SearchModel search) {
        var request = new ListGrantSupportQueryRequest(model);
        
        //Search Filter
        if (ModelState.IsValid && !string.IsNullOrEmpty(search.Query)) {
            ViewData["Search"] = search.Query;
            request.Filter = x => x.Title.Contains(search.Query);
        }

        ListGrantSupportQueryResponse response = await _mediator.Send(request);
        return this.ResponseView(response);
    }


    public IActionResult Create() {
        return View(new GrantSupportCreateDto());
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.GrantSupport,
        ActionType = ActionType.Writing,
        Definition = "Hibe ve Destek Ekleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.GrantSupport.Create
    )]
    public async Task<IActionResult> Create(GrantSupportCreateDto _grantSupportCreateDto) {
        if (ModelState.IsValid) {
            var response = await _mediator.Send(new CreateGrantSupportCommandRequest(_grantSupportCreateDto));
            return this.ResponseRedirectToActionForValidation(response, "List", _grantSupportCreateDto);
        }
        return this.View(_grantSupportCreateDto);
    }


    public async Task<IActionResult> Update(UpdateGrantSupportQueryRequest _updateGrantSupportQueryRequest) {
        var response = await _mediator.Send(_updateGrantSupportQueryRequest);
        return this.ResponseView(response);
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.GrantSupport,
        ActionType = ActionType.Updating,
        Definition = "Hibe ve Destek Güncelleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.GrantSupport.Update
    )]
    public async Task<IActionResult> Update(GrantSupportUpdateDto _grantSupportUpdateDto) {
        if (ModelState.IsValid) {
            var response = await _mediator.Send(new UpdateGrantSupportCommandRequest(_grantSupportUpdateDto));
            return this.ResponseRedirectToActionForValidation(response, "List", _grantSupportUpdateDto);
        }
        return View(_grantSupportUpdateDto);
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.GrantSupport,
        ActionType = ActionType.Deleting,
        Definition = "Hibe ve Destek Silme Yetkisi",
        Identifier = EndpointDefaults.Identifier.GrantSupport.Delete
    )]
    public async Task<IActionResult> Remove(RemoveGrantSupportCommandRequest _removeGrantSupportCommandRequest) {
        var response = await _mediator.Send(_removeGrantSupportCommandRequest);
        return this.ResponseRedirectToAction(response, "List");
    }
}

