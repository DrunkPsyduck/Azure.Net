using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mvcStorage.Services;

namespace mvcStorage
{
    public class Startup
    {
        IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            String storageKey = this.Configuration["StorageKeyAccount"];
            services.AddTransient(x => new ServiceStorageFile(storageKey));
            services.AddTransient(x => new ServiceStorageBlob(storageKey));
            services.AddTransient(X => new ServiceStorageTables(storageKey));

            services.AddTransient<ServiceTableAlumno>();

     
            String servicebuskeys = this.Configuration["ServiceBusKey"];
            services.AddTransient(x => new ServiceQueueBus(servicebuskeys));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
