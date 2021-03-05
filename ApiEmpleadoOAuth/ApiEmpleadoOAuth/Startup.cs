using ApiEmpleadoOAuth.Data;
using ApiEmpleadoOAuth.Helpers;
using ApiEmpleadoOAuth.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpleadoOAuth
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
            String cadenaLocal = this.Configuration.GetConnectionString("sql");

            services.AddTransient<RepositoryEmpleados>();
            services.AddDbContext<EmpleadosContext>(options => options.UseSqlServer(cadenaLocal));

            services.AddTransient<HelperToken>();

            services.AddSwaggerGen(options =>
            {
            options.SwaggerDoc(name: "v1", new OpenApiInfo{
                Title = "API Empleado OAuth",
                    Version = "V1",
                    Description = "Ejemplo seguridad OAuthToken"
                });
            });

            HelperToken helper = new HelperToken(Configuration);
            //add authentication
            services.AddAuthentication(helper.GetAuthOptions()).AddJwtBearer(helper.GetJwtBearerOptions());

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "v1");
                options.RoutePrefix = "";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
