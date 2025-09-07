using Application.Dtos.ProductGrowingSuggestionCategory;
using Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.CreateProductGrowingSuggestionCategory;
using Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.RemoveProductGrowingSuggestionCategory;
using Application.Features.CQRS.Queries.ProductGrowingSuggestionCategory.ListProductGrowingSuggestionCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductGrowingSuggestionCategoryController : Controller
    {
        private readonly IMediator _mediator;


        public ProductGrowingSuggestionCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new ListProductGrowingSuggestionCategoryQueryRequest());
            return this.ResponseView(response);
        }


        public async Task<IActionResult> Remove(RemoveProductGrowingSuggestionCategoryCommandRequest _removeProductGrowingSuggestionCategoryCommandRequest)
        {
            var response = await _mediator.Send(_removeProductGrowingSuggestionCategoryCommandRequest);
            return this.ResponseRedirectToAction(response, "List");
        }


        public IActionResult Create()
        {
            return View(new ProductGrowingSuggestionCategoryCreateDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductGrowingSuggestionCategoryCreateDto _productGrowingSuggestionCategoryCreateDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(new CreateProductGrowingSuggestionCategoryCommandRequest(_productGrowingSuggestionCategoryCreateDto));
                return this.ResponseRedirectToActionForValidation((Common.ResponseObjects.IResponse)response, "List", "ProductGrowingSuggestionCategory");
            }
            return View(_productGrowingSuggestionCategoryCreateDto);
        }
    }
}