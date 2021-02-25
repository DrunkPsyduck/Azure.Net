using ServiceDoctoresSQL.Models;
using ServiceDoctoresSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDoctoresSQL
{
    public class ServicioDoctor : IServiceDoctor
    {
        RepositoryDoctor repo;
        public ServicioDoctor()
        {
            this.repo = new RepositoryDoctor();
        }

        public Doctor BuscarDoctor(int id)
        {
            return this.repo.BuscarDoctor(id);
        }

        public List<Doctor> GetDoctores()
        {
            return this.repo.GetDoctores();
        }
    }
}
