using Application.Dtos.ProductGrowingSuggestion;
using MediatR;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.CreateProductGrowingSuggestion
{
    public class CreateProductGrowingSuggestionCommandRequest :  IRequest<CreateProductGrowingSuggestionCommandResponse>
    {
        public ProductGrowingSuggestionCreateDto? ProductGrowingSuggestionCreateDto { get; set; }
       
        public CreateProductGrowingSuggestionCommandRequest(ProductGrowingSuggestionCreateDto? productGrowingSuggestionCreateDto)
        {
            ProductGrowingSuggestionCreateDto = productGrowingSuggestionCreateDto;
        }
    }

    
    
}