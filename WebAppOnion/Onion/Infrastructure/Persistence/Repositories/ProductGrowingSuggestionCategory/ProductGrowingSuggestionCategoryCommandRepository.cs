using Application.Interfaces.Repository.ProductGrowingSuggestionCategory;
using Persistence.Contexts;

namespace Persistence.Repositories.ProductGrowingSuggestionCategory;

    public class ProductGrowingSuggestionCategoryCommandRepository : CommandRepository<Domain.Entities.Concrete.ProductGrowingSuggestionCategory>, IProductGrowingSuggestionCategoryCommandRepository
{
        public ProductGrowingSuggestionCategoryCommandRepository(DefaultContext context) : base(context)
        {

        }
}
    
