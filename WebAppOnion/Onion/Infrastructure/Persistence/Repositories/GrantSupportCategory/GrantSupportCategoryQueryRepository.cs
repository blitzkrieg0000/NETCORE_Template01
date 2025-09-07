using Application.Interfaces.Repository.GrantSupportCategory;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.GrantSupportCategory
{
    public class GrantSupportCategoryQueryRepository : QueryRepository<Domain.Entities.Concrete.GrantSupportCategory> ,IGrantSupportCategoryQueryRepository
    {
        public GrantSupportCategoryQueryRepository(DefaultContext context) : base(context)
        {
        }
    }
}
