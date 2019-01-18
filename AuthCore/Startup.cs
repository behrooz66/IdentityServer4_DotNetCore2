using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using AuthCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repo.Infrastructure;
using Repo.Generic;
using Microsoft.Extensions.Configuration;
using IdentityServer4.Validation;
using IdentityServer4.Stores;

namespace AuthCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json", true, true)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // todo: can connectionstring come from the REPO?

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // todo: is there a way to make this use the same connection string in REPO project?
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IUnitOfWork, UnitOfWork>()
                    .AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                    .AddTransient<IPersistedGrantStore, PersistedGrantStore>();

            services.AddIdentityServer()
                    .AddInMemoryApiResources(Config.GetApiResources())
                    .AddClientStore<ClientStore>()
                    .AddDeveloperSigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();

            // todo: is there a better way to manage CORS and not leaving it wide open?
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });
        }
    }
}
