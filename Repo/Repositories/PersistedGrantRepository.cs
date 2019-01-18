using DomainModel;
using Repo.Generic;
using Repo.Infrastructure;
using Repo.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.Repositories
{
    public class PersistedGrantRepository: Repository<PersistedGrant>, IPersistedGrantRepository
    {
        public PersistedGrantRepository(AppDbContext _context): base(_context)
        {

        }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}
