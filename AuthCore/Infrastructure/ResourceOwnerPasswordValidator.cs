using DomainModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Repo.Generic;
using Repo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthCore.Infrastructure
{
    public class ResourceOwnerPasswordValidator: IResourceOwnerPasswordValidator
    {
        private AppDbContext _context;
        private UnitOfWork uow;
        private IEventService _events;
        //protected readonly IRefreshTokenStore RefreshTokenStore;

        public ResourceOwnerPasswordValidator(AppDbContext context, IEventService events)
        {
            this._context = context;
            this.uow = new UnitOfWork(this._context);
            this._events = events;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (uow.Users.ValidatePassword(context.UserName, context.Password))
            {
                var z = uow.Users.Find(u => u.Username == context.UserName);
                var en = z.GetEnumerator();
                long userId = 0;
                while (en.MoveNext())
                {
                    userId = en.Current.Id;
                }

                context.Result = new GrantValidationResult(userId.ToString(), "password", null, "local", null);
                this.UpdateUserSession(context, userId);

                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return Task.FromResult(context.Result);
        }

        private void UpdateUserSession(ResourceOwnerPasswordValidationContext context, long userId)
        {
            var sessionId = context.Request.Raw.Get("session_id");
            var deviceId = context.Request.Raw.Get("device_id");
            var browser = context.Request.Raw.Get("browser");
            var os = context.Request.Raw.Get("os");
            UserSession US = uow.UserSessions.Find(us => us.UserId == userId && String.Equals(us.DeviceId, deviceId)).FirstOrDefault();
            if (US == null)
            {
                var newUs = new UserSession()
                {
                    UserId = userId,
                    SessionId = sessionId,
                    DeviceId = deviceId,
                    UpdateTime = DateTime.Now,
                    Browser = browser,
                    OperatingSystem = os
                };
                uow.UserSessions.Add(newUs);
                uow.Complete();
            }
            else
            {
                US.UpdateTime = DateTime.Now;
                uow.Complete();
            }
        }
    }
}
