using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Web.Models;
using Web.Services;

namespace Web
{
    public class Startup
    {

        #region Attributes
        public IConfiguration Configuration { get; }
        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRouting(x => x.LowercaseUrls = true);
            services.AddHttpClient<INewsletterSvc, NewsletterSvc>();
            services.AddHttpClient<ICatalogSvc, CatalogSvc>();
            services.AddHttpClient<IAccountSvc, AccountSvc>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = "/Account/SignIn";
                    o.AccessDeniedPath = "/Account/Forbidden";
                    o.Cookie.Name = ".hildenco.session";
                });

            //services.AddDistributedMemoryCache();

            //services.AddIdentity<User, IdentityRole>();

            //services.AddSession(o =>
            //{
            //    o.Cookie.Name = ".hildenco.session";
            //    o.IdleTimeout = TimeSpan.FromSeconds(10);
            //    o.Cookie.HttpOnly = true;
            //    o.Cookie.IsEssential = true;
            //});

            // allow auto-rebuilding the cshtml after changes (dev-only)
            // Ref: https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-compilation?view=aspnetcore-3.0#runtime-compilation
#if DEBUG
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
#else
            services.AddControllersWithViews();
#endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpContextItemsMiddleware();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            logger.LogInformation($"NewsletterSvc: {Configuration["Services:Newsletter"]}, CatalogSvc: {Configuration["Services:Catalog"]}");
        }
    }
}