using ApiEmpleadoOAuth.Data;
using ApiEmpleadoOAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmpleadoOAuth.Repositories
{
    public class RepositoryEmpleados
    {
        EmpleadosContext context;
        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            return this.context.Empleado.ToList();
        }

        public Empleado BuscarEmpleado(int id) {
            return this.context.Empleado.SingleOrDefault(x => x.IdEmpleado == id);
        }

        public Empleado ExisteEmpleado(String Apellido, int idEmpleado)
        {
            return this.context.Empleado.SingleOrDefault(x => x.Apellido == Apellido && x.IdEmpleado == idEmpleado);
        }
    }
}
