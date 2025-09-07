using Application.Dtos.ProductGrowingSuggestion;
using Application.Features.CQRS.Commands.ProductGrowingSuggestion.CreateProductGrowingSuggestion;
using Application.Features.CQRS.Commands.ProductGrowingSuggestion.Remove_ProductGrowingSuggestion;
using Application.Features.CQRS.Commands.ProductGrowingSuggestion.Update_ProductGrowingSuggestion;
using Application.Features.CQRS.Queries.ProductGrowingSuggestion.GetRangeProductGrowingSuggestion;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductGrowingSuggestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductGrowingSuggestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetRangeProductGrowingSuggestionQueryRequest _getRangeProductGrowingSuggestionQueryRequest)
        {
            _getRangeProductGrowingSuggestionQueryRequest.Filter = x => x.Active;
            var response = await _mediator.Send(_getRangeProductGrowingSuggestionQueryRequest);
            return this.ResponseOkResult(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveProductGrowingSuggestionCommandRequest _removeProductGrowingSuggestionCommandRequest)
        {
            var response = await _mediator.Send(_removeProductGrowingSuggestionCommandRequest);
            return this.ResponseOkResult(response);
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductGrowingSuggestionCreateDto _productGrowingSuggestionCreateDto)
        {
            _productGrowingSuggestionCreateDto.Files = Request.Form.Files;
            var response = await _mediator.Send(new CreateProductGrowingSuggestionCommandRequest(_productGrowingSuggestionCreateDto));
            return this.ResponseCreatedResult(response);
        }


        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromForm] ProductGrowingSuggestionUpdateDto _productGrowingSuggestionUpdateDto)
        {
            _productGrowingSuggestionUpdateDto.Files = Request.Form.Files;
            var response = await _mediator.Send(new UpdateProductGrowingSuggestionCommandRequest(_productGrowingSuggestionUpdateDto));
            return this.ResponseCreatedResult(response);
        }

    }
}
