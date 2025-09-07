using Application.Interfaces.Repository.GrantSupportCategory;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.GrantSupportCategory
{
    public class GrantSupportCategoryCommandRepository : CommandRepository<Domain.Entities.Concrete.GrantSupportCategory>, IGrantSupportCategoryCommandRepository
    {
        public GrantSupportCategoryCommandRepository(DefaultContext context) : base(context)
        {
        }
    }
}
