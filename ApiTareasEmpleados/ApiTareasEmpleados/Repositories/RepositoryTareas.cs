using ApiTareasEmpleados.Data;
using ApiTareasEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTareasEmpleados.Repositories
{
    public class RepositoryTareas
    {
        TareasContext context;
        public RepositoryTareas(TareasContext context)
        {
            this.context = context;
        }

        public List<Tareas> GetTareas()
        {
            return this.context.Tareas.ToList();
        }

        public Tareas BuscarTareas(int idtarea)
        {
            return this.context.Tareas.SingleOrDefault(x=> x.IdTarea == idtarea);
        }

        private int GetMaxTareas()
        {
            return this.context.Tareas.Max(x => x.IdTarea) + 1;
        }

        public void CrearTarea(String nombre, String descripcion, int idempleado)
        {
            Tareas tarea = new Tareas();
            tarea.IdEmpleado = this.GetMaxTareas();
            tarea.Nombre = nombre;
            tarea.Descripcion = descripcion;
            tarea.IdEmpleado = idempleado;
            tarea.Estado = "NEW";
            this.context.Tareas.Add(tarea);
            this.context.SaveChanges();

        }

        //Metodo que utiliza logic app para comprobar si hay nuevas tareas
        public List<Tareas> GetTareasEmpleado(int idempleado)
        {
            return this.context.Tareas.Where(z => z.IdEmpleado == idempleado && z.Estado == "NEW").OrderByDescending(x=>x.IdTarea).ToList();
        }
        
    }
}
