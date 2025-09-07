using MediatR;

namespace Application.Features.CQRS.Commands.ProductGrowingSuggestion.Remove_ProductGrowingSuggestion
{
   public class RemoveProductGrowingSuggestionCommandRequest : IRequest<RemoveProductGrowingSuggestionCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
