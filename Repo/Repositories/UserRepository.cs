using CryptoHelper;
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
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _context): base(_context)
        {

        }

        public bool ValidatePassword(string username, string plainPassword)
        {
            var user = AppContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;
            if (Crypto.VerifyHashedPassword(user.Password, plainPassword)) return true;
            return false;
        }

        public IEnumerable<UserClaim> GetUserClaims(long userId)
        {
            return AppContext.UserClaims.Where(c => c.UserId == userId).ToList();
        }

        public User Get(long id)
        {
            return AppContext.Users.Where(u => u.Id == id).FirstOrDefault();
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
