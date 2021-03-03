using ApiCrudDepartamentos.Models;
using ApiCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        RepositoryDepartamentos repo;

        public DepartamentoController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Departamento>> GetDepartamentos()
        {
            return this.repo.GetDepartamentos();
        }
        [HttpGet("{id}")]
        public ActionResult<Departamento> BuscarDepartamento(int id)
        {
            return this.repo.BuscarDepartamento(id);
        }

        //Post api/[controller]
        //Solo uno por defecto
       [HttpPost]
       public void InsertarDepartamento(Departamento departamento)
        {
            this.repo.InsertarDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
        }
        //PUT api/[Controller]
        [HttpPut]
        public void ModificarDepartamento(Departamento departamento)
        {
            this.repo.ModificarDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
        }
        [HttpDelete("{id}")]
        public void EliminarDepartamento(int id)
        {
            this.repo.EliminarDepartamento(id);
        }
    }
 
}
