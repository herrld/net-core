using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using HomePage.Services;
using Microsoft.Extensions.Configuration;
using SqlServerDataAccess;
using HomePageDataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using HomePageDataInterfaces;

namespace HomePage
{
    public class Startup
    {
        private IHostingEnvironment env;
        private IConfigurationRoot config;

        public Startup(IHostingEnvironment env)
        {
            this.env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(this.env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();// currently overriding to address using env variables

            this.config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<HomepageContext>();
            services.AddScoped<IHomepageContext, HomepageContext>();
            services.AddTransient<DataSeedService>();
            services.AddMvc();
            services.AddIdentity<HomepageUser, IdentityRole>(config =>
             {
                 config.Password.RequiredLength = 1;
                 config.Password.RequireDigit = false;
                 config.Password.RequireNonAlphanumeric = false;
                 config.Password.RequireUppercase = false;
             })
             .AddEntityFrameworkStores<HomepageContext>()
             .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/Login";
                config.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = async ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = 401;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        await Task.Yield();
                    }
                };
            });


            services.AddSingleton<IConfigurationRoot>(this.config);

            if (this.env.IsEnvironment("Development") || this.env.IsEnvironment("RandomEnvLikeTest"))
            {
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                // implement real services
            }


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeedService seedService)
        {
            
            if (env.IsDevelopment() || env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(config =>
            {
                //config.MapRoute(
                //    name:"app",
                //    template: "App/{*catchall}",
                //    defaults: new { controller = "App", action = "Index" });

                config.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");

            });
            seedService.SeedData().Wait();
        }
    }
}
