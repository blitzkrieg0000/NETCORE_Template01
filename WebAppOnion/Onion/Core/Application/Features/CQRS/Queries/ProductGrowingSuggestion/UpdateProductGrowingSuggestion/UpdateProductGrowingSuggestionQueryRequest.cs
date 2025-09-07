using MediatR;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.UpdateProductGrowingSuggestion
{
    public class UpdateProductGrowingSuggestionQueryRequest : IRequest<UpdateProductGrowingSuggestionQueryResponse>
    {
        public Guid Id { get; internal set; }
    }
}
