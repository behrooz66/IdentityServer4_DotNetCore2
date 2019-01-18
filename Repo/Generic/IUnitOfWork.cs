using Repo.RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.Generic
{
    public interface IUnitOfWork : IDisposable
    {
        //IRepos will add up here...
        IClientRepository Clients {get;set;}
        IUserRepository Users { get; set; }
        IUserSessionRepository UserSessions { get; set; }
        IPersistedGrantRepository PersistedGrants { get; set; }

        int Complete();
    }
}
