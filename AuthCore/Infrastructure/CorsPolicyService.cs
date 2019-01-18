using DomainModel;
using IdentityServer4.Services;
using Repo.Generic;
using Repo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCore.Infrastructure
{
    public class CorsPolicyService: ICorsPolicyService
    {
        private AppDbContext _context;
        private UnitOfWork uow;

        public CorsPolicyService(AppDbContext context)
        {
            this._context = context;
            this.uow = new UnitOfWork(context);
        }

        public Task<bool> IsOriginAllowedAsync(string origin)
        {

            List<ClientCorsOrigin> origins = new List<ClientCorsOrigin>();
            var clients = uow.Clients.GetAll().Select(x => x.ClientId).ToList();
            foreach (var c in clients)
            {
                var x = uow.Clients.GetCorsOrigins(c).ToList();
                origins.AddRange(x);
            }

            return Task.FromResult<bool>(origins.Select(o => o.Origin).Contains(origin));
        }
    }
}
