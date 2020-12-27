using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using VesizleMvcCore.Constants;
using VesizleMvcCore.Helpers;
using VesizleMvcCore.Identity;
using VesizleMvcCore.Identity.CookieConfig;
using VesizleMvcCore.Identity.IdentityConfig;
using VesizleMvcCore.NodejsApi.Api;
using VesizleMvcCore.NodejsApi.Api.Abstract;
using Westwind.AspNetCore.LiveReload;

namespace VesizleMvcCore
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
            services.AddDbContext<VesizleIdentityDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddIdentity<VesizleUser, IdentityRole>().AddEntityFrameworkStores<VesizleIdentityDbContext>()
                .AddDefaultTokenProviders().AddDefaultTokenProviders(); ;

            services.AddTransient<IPasswordValidator<VesizleUser>, CustomPasswordPolicy>();
            services.AddTransient<IRoleValidator<IdentityRole>, RoleValidator<IdentityRole>>();
            services.AddTransient<IUserValidator<VesizleUser>, UserValidator<VesizleUser>>();
            services.AddTransient<IPasswordHasher<VesizleUser>, PasswordHasher<VesizleUser>>();
            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Logout";
                options.AccessDeniedPath = "/Home";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder()
                {
                    Name = ".AspNetCore.Identity.Application.VesizleApp",
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    SecurePolicy = CookieSecurePolicy.Always
                };
            });
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy(UserRoles.Standard, policy =>
                {
                    policy.RequireRole(UserRoles.Standard);
                });
                opts.AddPolicy(UserRoles.Manager, policy =>
                {
                    policy.RequireRole(UserRoles.Manager);
                });
                opts.AddPolicy(UserRoles.Manager, policy =>
                {
                    policy.RequireRole(UserRoles.Manager);
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddLiveReload();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddHttpClient(AppConstants.HttpClientKey, client =>
             {
                 client.BaseAddress = new Uri(AppConstants.NodeJsApiUrl);
                 client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
             });
            services.AddScoped<ISearchService, SearchApi>();
            services.AddScoped<IMovieService, MoviesApi>();
            services.AddSession();
            services.AddHttpContextAccessor();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseLiveReload();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath = new PathString("/node_modules")
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapAreaControllerRoute(
                //    "admin", "Administration",
                //    "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                //);
            });
        }
    }
}
