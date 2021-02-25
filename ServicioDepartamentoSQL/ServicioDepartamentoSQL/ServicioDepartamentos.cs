
using ServicioDepartamentoSQL;
using ServicioDepartamentoSQL.Models;
using ServicioDepartamentoSQL.Repositories;
using ServicioDepartamentoSQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDepartamentoSQL
{
    public class ServicioDepartamentos : IServiceDepartamento
    {
        RepositoryDepartamentos repo;

        public ServicioDepartamentos()
        {
            this.repo = new RepositoryDepartamentos();
        }

        public Departamento BuscarDepartamento(int id)
        {
            return this.repo.BuscarDepartamento(id);
        }

        public List<Departamento> GetDepartamentos()
        {
            return this.repo.GetDepartamentos();
        }
    }
}
