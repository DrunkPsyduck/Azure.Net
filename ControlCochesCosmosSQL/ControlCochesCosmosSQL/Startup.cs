using ControlCochesCosmosSQL.Data;
using ControlCochesCosmosSQL.Repositories;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(ControlCochesCosmosSQL.Startup))]
namespace ControlCochesCosmosSQL { 

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<RepositoryCoches>();
            String cadena = Environment.GetEnvironmentVariable("cadenaazure");
            builder.Services.AddDbContext<CochesContext>(options => options.UseSqlServer(cadena));

        }
    }
}
