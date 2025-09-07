
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.CQRS.Queries.ProductGrowingSuggestion.GetRangeProductGrowingSuggestion
{
    public class GetRangeProductGrowingSuggestionQueryRequest : IRequest<GetRangeProductGrowingSuggestionQueryResponse>
    {
        public int Range { get; set; }
        public int Skip { get;set; }

        public Expression<Func<Domain.Entities.Concrete.ProductGrowingSuggestion, bool>> Filter = x => true;
    }
}