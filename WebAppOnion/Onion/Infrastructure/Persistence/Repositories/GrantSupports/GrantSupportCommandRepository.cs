using Application.Interfaces.Repository.GrantSupports;
using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories.GrantSupports;


public class GrantSupportCommandRepository : CommandRepository<GrantSupport>, IGrantSupportCommandRepository {
    public GrantSupportCommandRepository(DefaultContext context) : base(context) {
    }
}

