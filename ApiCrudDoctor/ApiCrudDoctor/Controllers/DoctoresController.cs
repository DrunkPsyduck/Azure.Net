using ApiCrudDoctor.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NugetDoctorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudDoctor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        RepositoryDoctores repo;
        public DoctoresController(RepositoryDoctores repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Doctor>> GetDoctores()
        {
            return this.repo.GetDoctores();
        }

        [HttpGet("{id}")]
        public ActionResult<Doctor> BuscarDoctor(int id)
        {
            return this.repo.BuscarDoctor(id);
        }

        [HttpPost]
        public void InsertarDoctor(Doctor doc)
        {
            this.repo.InsertarDoctor(doc.IdDoctor, doc.Apellido, doc.Especialidad, doc.Hospital, doc.Salario);
        }

        [HttpPut]
        public void UpdateDoctor(Doctor doc)
        {
            this.repo.UpdateDoctor(doc.IdDoctor, doc.Apellido, doc.Especialidad, doc.Hospital, doc.Salario);
        }
        [HttpDelete("{id}")]
        public void DeleteDoctor(int id)
        {
            this.repo.DeleteDoctor(id);
        }

        [HttpPut]
        [Route("[action]/{incremento}/{hospital}")]
        public void IncrementarSalario(int incremento, int hospital)
        {
            this.repo.IncrementarSalario(incremento, hospital);
        }

    }
}
