using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.CreateProductGrowingSuggestion
{
    public class CreateProductGrowingSuggestionCommandResponse : Response
    {
        public CreateProductGrowingSuggestionCommandResponse(ResponseType responseType) : base(responseType)
        {
        }
            public CreateProductGrowingSuggestionCommandResponse(ResponseType responseType, string message) : base(responseType, message) {

            }

        }
    }
    
    
