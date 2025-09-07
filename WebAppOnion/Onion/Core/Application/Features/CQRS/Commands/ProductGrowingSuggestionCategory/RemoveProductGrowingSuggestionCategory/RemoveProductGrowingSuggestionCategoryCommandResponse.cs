using Common.ResponseObjects;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestionCategory.RemoveProductGrowingSuggestionCategory
{
    public class RemoveProductGrowingSuggestionCategoryCommandResponse : Response
    {
        public RemoveProductGrowingSuggestionCategoryCommandResponse(ResponseType responseType) : base(responseType)
        {
        }

        public RemoveProductGrowingSuggestionCategoryCommandResponse(ResponseType responseType, string message) : base(responseType, message)
        {
        }
    }

}