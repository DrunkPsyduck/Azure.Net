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
using MvcClienteApiDepartamento.Services;
using MvcCoreDoctores.Services;

namespace MvcCore
{
    public class Startup
    {
        IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            String urldoctores = "https://apidoctoresmc.azurewebsites.net/";

            String urlapidepartamentos = this.configuration["urlapidepartamentos"];

            String urlapidoctores = this.configuration["urlapidoctores"];
            services.AddTransient(x => new ServiceDoctores(urlapidoctores));

            services.AddTransient(x => new ServiceDepartamentos(urlapidepartamentos));

            //inyeccion sin url
            services.AddTransient<ServiceApiDoctores>();

            //inyeccion con url
            //services.AddTransient<ServiceApiDoctores>(x => new ServiceApiDoctores(urldoctores));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
