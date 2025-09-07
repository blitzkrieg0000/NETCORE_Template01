using Application.Interfaces.Repository.ProductGrowingSuggestion;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ProductGrowingSuggestion
{
    public class ProductGrowingSuggestionCommandRepository : CommandRepository<Domain.Entities.Concrete.ProductGrowingSuggestion> , IProductGrowingSuggestionCommandRepository
    {
        public ProductGrowingSuggestionCommandRepository(DefaultContext context) : base(context)
        {
        }
    }
}
