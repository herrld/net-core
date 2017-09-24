using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CorseFromGround.Services;
using Microsoft.Extensions.Configuration;
using CorseFromGround.DataAccess;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using CouseFromGround.DataModels;
using CorseFromGround.ViewModels;

namespace CorseFromGround
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
                .AddEnvironmentVariables();

            this.config = builder.Build();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            if (this.env.IsEnvironment("Development") || this.env.IsEnvironment("custom"))
            {
                // resolve and cach
                //services.AddTransient<IMailService, DebugMailService>();

                // new instance for each request
                services.AddScoped<IMailService, DebugMailService>();

                // allways use same instance
                //services.AddSingleton<IMailService, DebugMailService>(); 
            }

            services.AddSingleton(this.config);

            services.AddDbContext<WorldContext>();
            services.AddTransient<WorldContextSeedData>();
            services.AddScoped<IWorldRepository, WorldRepository>();
            services.AddLogging();
            services.AddMvc();
            //services.AddMvc()
            //    .AddJsonOptions(config =>
            //    {
            //        config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            WorldContextSeedData seeder, ILoggerFactory loggingFactory)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<TripViewModel, Trip>().ReverseMap();
                config.CreateMap<StopViewModel, Stop>().ReverseMap();
            });

            loggerFactory.AddConsole();

            if (!env.IsEnvironment("Production"))
            {
                app.UseDeveloperExceptionPage();
                loggingFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggingFactory.AddDebug(LogLevel.Error);
            }
            app.UseStaticFiles();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name:"Default",
                    template:"{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index", id="" }
                    );
                
            });

            seeder.SeedData().Wait();
            //app.UseStaticFiles();
            
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
