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
    public class UserSessionRepository: Repository<UserSession>, IUserSessionRepository
    {
        public UserSessionRepository(AppDbContext _context) : base(_context)
        {

        }


    }
}
