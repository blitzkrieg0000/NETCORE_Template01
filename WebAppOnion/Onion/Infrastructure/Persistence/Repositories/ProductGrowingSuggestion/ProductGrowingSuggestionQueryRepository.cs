﻿using Application.Interfaces.Repository.ProductGrowingSuggestion;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ProductGrowingSuggestion;

public class ProductGrowingSuggestionQueryRepository : QueryRepository<Domain.Entities.Concrete.ProductGrowingSuggestion>, IProductGrowingSuggestionQueryRepository
{
    public ProductGrowingSuggestionQueryRepository(DefaultContext context) : base(context)
    {
    }
}
