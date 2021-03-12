using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TaskWebJob.Data;
using TaskWebJob.Repositories;

namespace TaskWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            String cnn = "Data Source=sqlmarioc.database.windows.net;Initial Catalog=PROYECTO;User ID=adminsql;Password=Admin123";

            var provider = new ServiceCollection().AddTransient<RepositoryWebJob>()
                .AddDbContext<WebJobContext>(x => x.UseSqlServer(cnn)).BuildServiceProvider();
            RepositoryWebJob repo = provider.GetService<RepositoryWebJob>();
            //Console.WriteLine("Pulse una tecla para iniciar");
            //Console.ReadLine();
            repo.PopulateDataWebJob();
            //Console.WriteLine("proceso terminado. Pulse Enter para finalizar");
            //Console.ReadLine();
        }
    }
}
