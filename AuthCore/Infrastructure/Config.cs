using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCore.Infrastructure
{
    public class Config
    {
        // At the moment using in-memory API resources
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "Main Api")
                {
                    ApiSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }





    }
}
