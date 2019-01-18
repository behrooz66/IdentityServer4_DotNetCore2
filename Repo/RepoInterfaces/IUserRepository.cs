using DomainModel;
using Repo.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.RepoInterfaces
{
    public interface IUserRepository: IRepository<User>
    {
        User Get(long id);
        bool ValidatePassword(string username, string plainPassword);
        IEnumerable<UserClaim> GetUserClaims(long userId);
    }
}
