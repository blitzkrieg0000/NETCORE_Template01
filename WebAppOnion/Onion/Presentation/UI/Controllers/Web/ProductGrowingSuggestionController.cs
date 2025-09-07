using Application.Dtos.ProductGrowingSuggestion;
using Application.Features.CQRS.Commands.ProductGrowingSuggestion.CreateProductGrowingSuggestion;
using Application.Features.CQRS.Commands.ProductGrowingSuggestion.Remove_ProductGrowingSuggestion;
using Application.Features.CQRS.Commands.ProductGrowingSuggestion.Update_ProductGrowingSuggestion;
using Application.Features.CQRS.Queries.ProductGrowingSuggestion.ListProductGrowingSuggestion;
using Application.Features.CQRS.Queries.ProductGrowingSuggestion.UpdateProductGrowingSuggestion;
using Application.Models.Paginator;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web
{
    public class ProductGrowingSuggestionController : Controller
    {
        private readonly IMediator _mediator;

        public ProductGrowingSuggestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> List(PaginatorModel model)
        {
            ListProductGrowingSuggestionQueryResponse response = await _mediator.Send(new ListProductGrowingSuggestionQueryRequest(model));
            return this.ResponseView(response);
        }


        public IActionResult Create()
        {
            return View(new ProductGrowingSuggestionCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductGrowingSuggestionCreateDto _productGrowingSuggestionCreateDto)
        {
            var response = await _mediator.Send(new CreateProductGrowingSuggestionCommandRequest(_productGrowingSuggestionCreateDto));
            return this.ResponseRedirectToActionForValidation(response, "List", _productGrowingSuggestionCreateDto);
        }

        public async Task<IActionResult> Update(UpdateProductGrowingSuggestionQueryRequest _updateProductGrowingSuggestionQueryRequest)
        {
            var response = await _mediator.Send(_updateProductGrowingSuggestionQueryRequest);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductGrowingSuggestionUpdateDto _productGrowingSuggestionUpdateDto)
        {
            var response = await _mediator.Send(new UpdateProductGrowingSuggestionCommandRequest(_productGrowingSuggestionUpdateDto));
            return this.ResponseRedirectToActionForValidation(response, "List", _productGrowingSuggestionUpdateDto);
        }
        public async Task<IActionResult> Remove(RemoveProductGrowingSuggestionCommandRequest _removeProductGrowingSuggestionCommandRequest)
        {
            var response = await _mediator.Send(_removeProductGrowingSuggestionCommandRequest);
            return this.ResponseRedirectToAction(response, "List");
        }
    }
    
}
