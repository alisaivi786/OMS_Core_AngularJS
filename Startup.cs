using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OMS.Filters;
using OMS.Helpers;
using OMS.Jwt;
using OMS.Models.Context;
using OMS.Models.DAL;
using OMS.Models.Interface;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS
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

            services.AddControllersWithViews();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(SessionHelperAttribute));

            });

           
            services.AddDbContextPool<AppDBContext>(
               option => option.UseSqlServer(Constants.CONNECTION_STRING));
            

            services.AddScoped<IModules, ModuleRepository>();
            services.AddScoped<IRoles, RoleRepository>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, UserRepository>();
            services.AddSession(so =>
            {
                so.IdleTimeout = TimeSpan.FromMinutes(30);
                so.Cookie.HttpOnly = true;
                so.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.Secret_Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });

            RotativaConfiguration.Setup(env.WebRootPath,"Rotativa");
        }
    }
}
