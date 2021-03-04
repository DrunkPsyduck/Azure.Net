using ApiCrudDoctor.Data;
using NugetDoctorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudDoctor.Repositories
{
    public class RepositoryDoctores
    {
        DoctoresContext context;
        public RepositoryDoctores(DoctoresContext context)
        {
            this.context = context;
        }

        public List<Doctor> GetDoctores()
        {
            return this.context.Doctores.ToList();
        }

        public Doctor BuscarDoctor(int id)
        {
            return this.context.Doctores.SingleOrDefault(x => x.IdDoctor == id);
        }

        public void DeleteDoctor(int id)
        {
            Doctor doctor = BuscarDoctor(id);

            this.context.Doctores.Remove(doctor);
            this.context.SaveChanges();
        }

        public void InsertarDoctor(int id, String apellido, String especialidad, int hospital, int salario)
        {
            Doctor doctor = new Doctor();
            doctor.IdDoctor = id;
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Salario = salario;
            doctor.Hospital = hospital;
            this.context.Doctores.Add(doctor);
            this.context.SaveChanges();
        }

        public void UpdateDoctor(int id, String apellido, String especialidad, int hospital, int salario)
        {
            Doctor doctor = this.BuscarDoctor(id);
            doctor.Apellido = apellido;
            doctor.Especialidad = especialidad;
            doctor.Salario = salario;
            doctor.Hospital = hospital;
            this.context.SaveChanges();

        }

        public void IncrementarSalario(int incremento, int hospital)
        {
            List<Doctor> doctores = this.context.Doctores.Where(x => x.Hospital == hospital).ToList();
            foreach (Doctor doc in doctores)
            {
                doc.Salario += incremento;
            }
            this.context.SaveChanges();
        }
    }
}
