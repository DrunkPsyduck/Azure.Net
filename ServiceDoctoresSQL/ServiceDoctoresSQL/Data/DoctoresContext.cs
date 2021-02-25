using ServiceDoctoresSQL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDoctoresSQL.Data
{
    public class DoctoresContext : DbContext
    {
        public DoctoresContext() : base("name=cadenahospital") { }

        public DbSet<Doctor> Doctores { get; set; }
    }
}
