using DomainModel;
using Repo.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.RepoInterfaces
{
    public interface IPersistedGrantRepository: IRepository<PersistedGrant>
    {
    }
}
