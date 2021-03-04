using Microsoft.EntityFrameworkCore;
using NugetDoctorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudDoctor.Data
{
    public class DoctoresContext : DbContext
    {
        public DoctoresContext(DbContextOptions<DoctoresContext> options) : base(options) { }
        public DbSet<Doctor> Doctores { get; set; }
    }
}
