
using Application.Features.CQRS.Queries.ProductGrowingSuggestionCategory.List_ProductGrowingSuggestionCategory;
using MediatR;
using System.Linq.Expressions;


namespace Application.Features.CQRS.Queries.ProductGrowingSuggestionCategory.ListProductGrowingSuggestionCategory;

public class ListProductGrowingSuggestionCategoryQueryRequest : IRequest<ListProductGrowingSuggestionCategoryQueryResponse>
{

    public Expression<Func<Domain.Entities.Concrete.ProductGrowingSuggestionCategory, bool>> Filter = x => true;

    public ListProductGrowingSuggestionCategoryQueryRequest()
    {

    }

    public ListProductGrowingSuggestionCategoryQueryRequest(Expression<Func<Domain.Entities.Concrete.ProductGrowingSuggestionCategory, bool>> filter)
    {
       
    }
}
