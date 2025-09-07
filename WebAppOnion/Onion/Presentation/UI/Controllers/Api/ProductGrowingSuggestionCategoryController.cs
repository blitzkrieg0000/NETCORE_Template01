using Application.Features.CQRS.Queries.ProductGrowingSuggestionCategory.ListProductGrowingSuggestionCategory;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Api
{
    [Route("api/[controller]", Order = 2)]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProductGrowingSuggestionCategoryController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductGrowingSuggestionCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _mediator.Send(new ListProductGrowingSuggestionCategoryQueryRequest(x => x.Active));
            return this.ResponseOkResult(response);
        }
    }
}
