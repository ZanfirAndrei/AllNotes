using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AllNotes.Domain.EF.AllNotesContext;
using AllNotes.Domain.EF.Users;
using AllNotes.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AllNotes.WebApi
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
            //services.AddCors();

            services.AddControllers();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = " My API v1", Version = "v1" });
            });
            services.ConfigureDbContext(Configuration);
            services.InjectRepositories();
            services.InjectServices();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AllNotesDbContext>()
                .AddDefaultTokenProviders(); ;

            //services.AddScoped<IUserStore<User>, UserStore>();
           
            services.ConfigureApplicationCookie(options => {
                options.Cookie.Name = "auth_cookie";
                options.Cookie.Domain = "https://localhost:44342/api/";
                options.LoginPath = "/Account/Login/";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(365);
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = redirectContext =>
                    {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
                //options.Events = new CookieAuthenticationEvents
                //{
                //    OnRedirectToAccessDenied = redirectContext =>
                //    {
                //        redirectContext.HttpContext.Response.StatusCode = 403;
                //        return Task.CompletedTask;
                //    }
                //};
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => {
                    policy.RequireClaim(UsersRoles.User);
                });
                options.AddPolicy("Manager", policy => {
                    policy.RequireRole(UsersRoles.Manager);
                });
                options.AddPolicy("User", policy => {
                    policy.RequireRole(UsersRoles.Admin);
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();

       
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            //{
            //    options.Events.OnRedirectToAccessDenied = ReplaceRedirector(HttpStatusCode.Forbidden, options.Events.OnRedirectToAccessDenied);
            //    options.Events.OnRedirectToLogin = ReplaceRedirector(HttpStatusCode.Unauthorized, options.Events.OnRedirectToLogin);
            //});

            //services.AddIdentity<IdentityUser, IdentityRole>();

            //services.AddIdentityCore<IdentityUser<AppUser>>(options => { });


            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            //    {
            //        options.Events.OnRedirectToAccessDenied = ReplaceRedirector(HttpStatusCode.Forbidden, options.Events.OnRedirectToAccessDenied);
            //        options.Events.OnRedirectToLogin = ReplaceRedirector(HttpStatusCode.Unauthorized, options.Events.OnRedirectToLogin);
            //    });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
                //policy.AllowCredentials();
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //static Func<RedirectContext<CookieAuthenticationOptions>, Task> ReplaceRedirector(HttpStatusCode statusCode,
        //Func<RedirectContext<CookieAuthenticationOptions>, Task> existingRedirector) =>
        //context =>
        //{
        //    if (context.Request.Path.StartsWithSegments("/api"))
        //    {
        //        context.Response.StatusCode = (int)statusCode;
        //        return Task.CompletedTask;
        //    }
        //    return existingRedirector(context);
        //};
    }
}
