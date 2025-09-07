using Application.Dtos.ProductGrowingSuggestion;
using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.Remove_ProductGrowingSuggestion
{
    public class RemoveProductGrowingSuggestionCommandResponse : Response<ProductGrowingSuggestionDto>
    {
        public RemoveProductGrowingSuggestionCommandResponse(ResponseType responseType) : base(responseType)
        {
        }

        public RemoveProductGrowingSuggestionCommandResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }
    }
}
    
