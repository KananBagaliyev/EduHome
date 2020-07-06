using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndProject
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSession();

            services.AddIdentity<User, IdentityRole>(IdentityOptions => {
                IdentityOptions.Password.RequireDigit = true;
                IdentityOptions.Password.RequireLowercase = true;
                IdentityOptions.Password.RequireUppercase = true;
                IdentityOptions.Password.RequiredLength = 7;
                IdentityOptions.Password.RequireNonAlphanumeric = false;

                IdentityOptions.User.RequireUniqueEmail = true;

                IdentityOptions.Lockout.MaxFailedAccessAttempts = 5;
                IdentityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                IdentityOptions.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{ID?}");
            });
        }
    }
}
