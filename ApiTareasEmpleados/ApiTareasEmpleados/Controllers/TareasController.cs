using ApiTareasEmpleados.Data;
using ApiTareasEmpleados.Models;
using ApiTareasEmpleados.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTareasEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        RepositoryTareas repo;
        public TareasController(RepositoryTareas repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Tareas>> GetTareas()
        {
            return this.repo.GetTareas();
        }

        [HttpGet("{id}")]
        public ActionResult<Tareas> BuscarTarea(int id)
        {
            return this.repo.BuscarTareas(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void insertarTarea(Tareas tarea)
        {
            this.repo.CrearTarea(tarea.Nombre, tarea.Descripcion, tarea.IdEmpleado);
        }

        [HttpGet]
        [Route("[action]/{idempleado}/tasks")]
        public ActionResult<List<Tareas>> TareasEmpleado(int idempleado)
        {
            var model = new
            {
                value = this.repo.GetTareasEmpleado(idempleado)
            };
            return Ok(model);
        }
    }
}
