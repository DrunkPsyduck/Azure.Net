using ApiTareasEmpleados.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTareasEmpleados.Data
{
    public class TareasContext: DbContext
    {

        public TareasContext(DbContextOptions<TareasContext> options): base(options) { }

        public DbSet<Tareas> Tareas { get; set; }
    }
}
