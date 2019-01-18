using IdentityServer4.Models;
using IdentityServer4.Stores;
using Repo.Generic;
using Repo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCore.Infrastructure
{
    public class PersistedGrantStore: IPersistedGrantStore
    {
        private AppDbContext _context;
        private UnitOfWork uow;

        public PersistedGrantStore(AppDbContext context)
        {
            this._context = context;
            this.uow = new UnitOfWork(this._context);
        }

        public Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            // todo: why is this one not implemented? When do we need it?
            throw new NotImplementedException();
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            var pg = uow.PersistedGrants.Find(p => p.Key == key).FirstOrDefault();
            if (pg == null)
                return Task.FromResult<PersistedGrant>(null);
            PersistedGrant ps = new PersistedGrant()
            {
                ClientId = pg.ClientId,
                CreationTime = pg.CreationTime,
                Data = pg.Data,
                Expiration = pg.Expiration,
                Key = pg.Key,
                SubjectId = pg.SubjectId,
                Type = pg.Type
            };

            return Task.FromResult(ps);
        }

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            // todo: investigate whether needs implementation
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            // todo: investigate whether needs implementation
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            var pg = uow.PersistedGrants.Find(p => p.Key == key).FirstOrDefault();

            if (pg == null)
                throw new KeyNotFoundException();
            uow.PersistedGrants.Remove(pg);
            uow.Complete();
            return Task.CompletedTask;
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            uow.PersistedGrants.Add(new DomainModel.PersistedGrant()
            {
                ClientId = grant.ClientId,
                CreationTime = grant.CreationTime,
                Data = grant.Data,
                Expiration = grant.Expiration,
                Key = grant.Key,
                SubjectId = grant.SubjectId,
                Type = grant.Type
            });
            uow.Complete();
            return Task.CompletedTask;
        }
    }
}
