using APIDoctores.Models;
using APIDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        RepositoryDoctor repo;
        public DoctorController(RepositoryDoctor repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public ActionResult<List<Doctor>> GetDoctores()
        {
            return this.repo.GetDoctor();
        }

        [HttpGet("{id}")]
        public ActionResult<Doctor> GetDoctores(int id)
        {
            return this.repo.BuscarDoctor(id);  
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<String>> Especialidades()
        {
            return this.repo.GetEspecialidad();
        }

        [HttpGet]
        [Route("[action]/{especialidad}")]
        public ActionResult<List<Doctor>> DoctoresEspecialidad(String especialidad)
        {
            return this.repo.GetDoctoresEspecialidad(especialidad);
        }
        [HttpGet]
        [Route("{salario}/{especialidad}")]
        public ActionResult<List<Doctor>> DoctoresSalario(int salario, String especialidad)
        {
            return this.repo.GetDoctoresSalario(salario);
        }
    }
}
