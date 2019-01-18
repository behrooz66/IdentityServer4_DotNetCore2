using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class UserHelper
    {
        public static long GetCurrentUserId(ClaimsPrincipal user)
        {
            return long.Parse(user.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "sub").Value);
        }
    }
}
