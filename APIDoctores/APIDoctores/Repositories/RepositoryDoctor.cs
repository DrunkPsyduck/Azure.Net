using APIDoctores.data;
using APIDoctores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoctores.Repositories
{
   
    public class RepositoryDoctor
    {
        DoctorContext context;
        public RepositoryDoctor(DoctorContext context)
        {
            this.context = context;
        }

        public List<Doctor> GetDoctor()
        {
            return this.context.Doctores.ToList();
        }

        public Doctor BuscarDoctor(int id)
        {
            return this.context.Doctores.SingleOrDefault(x => x.IdHospital == id);
        }

        public List<String> GetEspecialidad()
        {
            var consulta = (from datos in this.context.Doctores select datos.Especialidad).Distinct();
            return consulta.ToList();
        }

        public List<Doctor> GetDoctoresEspecialidad(String especialidad)
        {
            return this.context.Doctores.Where(x => x.Especialidad == especialidad).ToList();
        }

        public List<Doctor> GetDoctoresSalario(int salario)
        {
            return this.context.Doctores.Where(x => x.Salario >= salario).ToList();
        }
    }
}
