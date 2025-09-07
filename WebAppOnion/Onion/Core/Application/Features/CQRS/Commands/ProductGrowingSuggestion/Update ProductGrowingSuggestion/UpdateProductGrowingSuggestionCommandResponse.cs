using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.Update_ProductGrowingSuggestion
{
    public class UpdateProductGrowingSuggestionCommandResponse : Response
    {
        public UpdateProductGrowingSuggestionCommandResponse(ResponseType responseType) : base(responseType)
        {
        }

        public UpdateProductGrowingSuggestionCommandResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }
    }

    
}