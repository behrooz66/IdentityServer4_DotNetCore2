using DomainModel;
using Repo.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.RepoInterfaces
{
    public interface IClientRepository: IRepository<Client>
    {
        IEnumerable<ClientSecret> GetSecrets(string clientId);
        IEnumerable<ClientGrantType> GetGrantTypes(string clientId);
        IEnumerable<ClientCorsOrigin> GetCorsOrigins(string clientId);
        IEnumerable<ClientScope> GetScopes(string clientId);
    }
}
