using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repo.Generic;
using Repo.Infrastructure;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();
            services.AddSingleton<IConfiguration>(Configuration);

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString)
            );

            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = Configuration.GetSection("CustomSettings").GetSection("Authority").GetSection("URL").Value;
                        options.RequireHttpsMetadata = bool.Parse(Configuration.GetSection("CustomSettings").GetSection("Authority").GetSection("RequireHTTPS").Value);
                        options.ApiName = Configuration.GetSection("CustomSettings").GetSection("Authority").GetSection("ApiName").Value;
                        options.ApiSecret = Configuration.GetSection("CustomSettings").GetSection("Authority").GetSection("ApiSecret").Value;
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(options =>
            {
                //options.WithOrigins("http://localhost:4200/").AllowAnyMethod();
                //todo: restrict it if you wish.
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });
            app.UseMvc();
        }
    }
}
