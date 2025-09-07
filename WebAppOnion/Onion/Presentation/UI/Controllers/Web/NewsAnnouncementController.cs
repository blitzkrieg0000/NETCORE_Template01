using Application.Attributes;
using Application.Consts.Auth;
using Application.Dtos.NewsAnnouncement;
using Application.Dtos.NewsAnnouncementCategory;
using Application.Enums;
using Application.Features.CQRS.Commands.NewsAnnouncement.CreateNewsAnnouncement;
using Application.Features.CQRS.Commands.NewsAnnouncement.RemoveNewsAnnouncement;
using Application.Features.CQRS.Commands.NewsAnnouncement.UpdateNewsAnnouncement;
using Application.Features.CQRS.Queries.NewsAnnoucement.UpdateNewsAnnouncement;
using Application.Features.CQRS.Queries.NewsAnnouncement.ListNewsAnnouncement;
using Application.Features.CQRS.Queries.NewsAnnouncementCategory.ListNewsAnnouncementCategory;
using Application.Models.NewsAnnouncement;
using Application.Models.Paginator;
using Application.Models.Search;
using Common.ResponseObjects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web;


[Authorize]
public class NewsAnnouncementController : Controller {
    private readonly IMediator _mediator;

    public NewsAnnouncementController(IMediator mediator) {
        _mediator = mediator;
    }


    //! LIST-----------------------------------------------------------------------------------------------------------
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncement,
        ActionType = ActionType.Reading,
        Definition = "Haber Listeleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncement.List
    )]
    public async Task<IActionResult> List(PaginatorModel paginatorModel, SearchModel search) {
        var request = new ListNewsAnnouncementQueryRequest(paginatorModel);

        if (ModelState.IsValid && !string.IsNullOrEmpty(search.Query)) {
            ViewData["Search"] = search.Query;
            request.Filter = x => x.Title.Contains(search.Query);
        }

        var response = await _mediator.Send(request);
        return this.ResponseView(response);
    }


    //! REMOVE---------------------------------------------------------------------------------------------------------
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncement,
        ActionType = ActionType.Deleting,
        Definition = "Haber Silme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncement.Delete
    )]
    public async Task<IActionResult> Remove(RemoveNewsAnnouncementCommandRequest _removeNewsAnnouncementCommandRequest) {
        var response = await _mediator.Send(_removeNewsAnnouncementCommandRequest);
        return this.ResponseRedirectToAction(response, "List");
    }


    //! UPDATE---------------------------------------------------------------------------------------------------------
    public async Task<IActionResult> Update(UpdateNewsAnnouncementQueryRequest _updateNewsAnnouncementQueryRequest) {
        var responseNewsAnnouncement = await _mediator.Send(_updateNewsAnnouncementQueryRequest);
        var responseNewsAnnouncementCategory = await _mediator.Send(new ListNewsAnnouncementCategoryQueryRequest());
        var data = new NewsAnnouncementUpdateViewModel() {
            NewsAnnouncementUpdateDto = responseNewsAnnouncement.Data,
            NewsAnnouncementCategoryDto = responseNewsAnnouncementCategory.Data
        };
        return this.ResponseView(new Response<NewsAnnouncementUpdateViewModel>(responseNewsAnnouncement.ResponseType, data));
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncement,
        ActionType = ActionType.Updating,
        Definition = "Haber Güncelleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncement.Update
    )]
    public async Task<IActionResult> Update(NewsAnnouncementUpdateViewModel _newsAnnouncementUpdateViewModel) {
        async Task<List<NewsAnnouncementCategoryDto>> GetAdditionalData() {
            var responseNewsAnnouncementCategory = await _mediator.Send(new ListNewsAnnouncementCategoryQueryRequest());
            return responseNewsAnnouncementCategory.Data;
        }

        if (ModelState.IsValid) {
            var response = await _mediator.Send(new UpdateNewsAnnouncementCommandRequest(_newsAnnouncementUpdateViewModel.NewsAnnouncementUpdateDto));
            if (response.ResponseType != ResponseType.Success) {
                _newsAnnouncementUpdateViewModel.NewsAnnouncementCategoryDto = await GetAdditionalData();
            }
            return this.ResponseRedirectToActionForValidation(response, "List", _newsAnnouncementUpdateViewModel);
        }
        _newsAnnouncementUpdateViewModel.NewsAnnouncementCategoryDto = await GetAdditionalData();
        return View(_newsAnnouncementUpdateViewModel);
    }


    //! CREATE---------------------------------------------------------------------------------------------------------
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncement,
        ActionType = ActionType.Writing,
        Definition = "Haber Ekleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncement.Create
    )]
    public async Task<IActionResult> Create() {
        var responseNewsAnnouncementCategory = await _mediator.Send(new ListNewsAnnouncementCategoryQueryRequest());
        var data = new NewsAnnouncementCreateViewModel() {
            NewsAnnouncementCategoryDto = responseNewsAnnouncementCategory.Data,
            NewsAnnouncementCreateDto = new NewsAnnouncementCreateDto()
        };
        return this.ResponseView(new Response<NewsAnnouncementCreateViewModel>(responseNewsAnnouncementCategory.ResponseType, data));
    }


    [HttpPost]
    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.NewsAnnouncement,
        ActionType = ActionType.Writing,
        Definition = "Haber Ekleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.NewsAnnouncement.Create
    )]
    public async Task<IActionResult> Create(NewsAnnouncementCreateViewModel _newsAnnouncementCreateViewModel) {
        async Task<IEnumerable<NewsAnnouncementCategoryDto>> GetAdditionalData() {
            var responseNewsAnnouncementCategory = await _mediator.Send(new ListNewsAnnouncementCategoryQueryRequest());
            return responseNewsAnnouncementCategory.Data;
        }

        if (ModelState.IsValid) {
            var response = await _mediator.Send(new CreateNewsAnnouncementCommandRequest(_newsAnnouncementCreateViewModel.NewsAnnouncementCreateDto));
            if (response.ResponseType != ResponseType.Success) {
                _newsAnnouncementCreateViewModel.NewsAnnouncementCategoryDto = await GetAdditionalData();
                return this.ResponseViewWithCustomModel(response, _newsAnnouncementCreateViewModel);
            }
            return this.ResponseRedirectToAction(response, "List");
        }

        _newsAnnouncementCreateViewModel.NewsAnnouncementCategoryDto = await GetAdditionalData();
        return View(_newsAnnouncementCreateViewModel);
    }

}
