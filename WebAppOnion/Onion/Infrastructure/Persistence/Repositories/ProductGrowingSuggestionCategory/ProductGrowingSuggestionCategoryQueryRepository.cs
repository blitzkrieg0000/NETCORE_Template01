using Application.Interfaces.Repository.ProductGrowingSuggestionCategory;
using Persistence.Contexts;

namespace Persistence.Repositories.ProductGrowingSuggestionCategory
{
    public class ProductGrowingSuggestionCategoryQueryRepository : QueryRepository<Domain.Entities.Concrete.ProductGrowingSuggestionCategory>, IProductGrowingSuggestionCategoryQueryRepository
    {
        public ProductGrowingSuggestionCategoryQueryRepository(DefaultContext context) : base(context)
        {
        }
    }
}

