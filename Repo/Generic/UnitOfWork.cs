using Repo.Infrastructure;
using Repo.RepoInterfaces;
using Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.Generic
{
    public class UnitOfWork: IUnitOfWork
    {
        private AppDbContext _context;

        public IClientRepository Clients { get; set; }
        public IUserRepository Users { get; set; }
        public IUserSessionRepository UserSessions { get; set; }
        public IPersistedGrantRepository PersistedGrants { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;

            // repos instantations here...
            Clients = new ClientRepository(this._context);
            Users = new UserRepository(this._context);
            UserSessions = new UserSessionRepository(this._context);
            PersistedGrants = new PersistedGrantRepository(this._context);
        }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
