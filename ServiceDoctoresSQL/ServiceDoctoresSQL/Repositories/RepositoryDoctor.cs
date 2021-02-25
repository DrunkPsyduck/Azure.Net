using ServiceDoctoresSQL.Data;
using ServiceDoctoresSQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDoctoresSQL.Repositories
{
    public class RepositoryDoctor
    {
        DoctoresContext context;
        public RepositoryDoctor()
        {
            this.context = new DoctoresContext();
        }

        public List<Doctor> GetDoctores()
        {
            return this.context.Doctores.ToList();
        }

        public Doctor BuscarDoctor(int id)
        {
            return this.context.Doctores.SingleOrDefault(x => x.IdDoctor == id);
        }
    }
}
