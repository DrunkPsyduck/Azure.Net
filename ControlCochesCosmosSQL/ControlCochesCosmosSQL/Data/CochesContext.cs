using ControlCochesCosmosSQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlCochesCosmosSQL.Data
{
    public class CochesContext : DbContext
    {

        public CochesContext(DbContextOptions<CochesContext> options) : base(options) { }

        public DbSet<Coche> coches { get; set; }

    }
}
