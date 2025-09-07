using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repository.ProductGrowingSuggestion
{
    public interface IProductGrowingSuggestionCommandRepository: ICommandRepository<Domain.Entities.Concrete.ProductGrowingSuggestion>
    {
    }
}
