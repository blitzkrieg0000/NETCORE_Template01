using Application.Dtos.ProductGrowingSuggestion;
using MediatR;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.Update_ProductGrowingSuggestion
{
    public class UpdateProductGrowingSuggestionCommandRequest : IRequest<UpdateProductGrowingSuggestionCommandResponse>
    {
       
        public ProductGrowingSuggestionUpdateDto? ProductGrowingSuggestionUpdateDto { get; }

        public UpdateProductGrowingSuggestionCommandRequest(ProductGrowingSuggestionUpdateDto? productGrowingSuggestionUpdateDto)
        {
            ProductGrowingSuggestionUpdateDto = productGrowingSuggestionUpdateDto;
        }
    
    
    }
}