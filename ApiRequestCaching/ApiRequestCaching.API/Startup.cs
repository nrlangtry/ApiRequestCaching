using ApiRequestCaching.Data;
using ApiRequestCaching.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ApiRequestCaching.API
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IDataRepository, CacheDataRepository>();
            services.AddScoped<IDataRepository, StaticCacheDataRepository>();

            services.AddScoped<DataRepositoryResolver>(serviceProvider => type =>
            {
                var dataRepositories = serviceProvider.GetServices<IDataRepository>();

                switch (type)
                {
                    case "Cache":
                        return dataRepositories.FirstOrDefault(x => x.GetType() == typeof(CacheDataRepository));
                    case "Static Cache":
                        return dataRepositories.FirstOrDefault(x => x.GetType() == typeof(StaticCacheDataRepository));
                    default:
                        return dataRepositories.FirstOrDefault(x => x.GetType() == typeof(DataRepository));
                }
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
