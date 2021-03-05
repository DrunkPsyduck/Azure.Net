using ApiEmpleadoOAuth.Models;
using ApiEmpleadoOAuth.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiEmpleadoOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Empleado>> GetEmpleados()
        {
            return this.repo.GetEmpleados();
        }

        [HttpGet("{id}")]
        public ActionResult<Empleado> GetEmpleado(int id)
        {
            return this.repo.BuscarEmpleado(id);
        }

        //Metodo con seguridad
        [HttpGet]
        [Route("[action]")]
        public ActionResult<Empleado> PerfilEmpleado()
        {
            //REcuperar Claim de UserData
            List<Claim> claims = HttpContext.User.Claims.ToList();

            //Buscar JSON del empleado con la key de UserData
            String jsonempleado = claims.SingleOrDefault(x => x.Type == "UserData").Value;

            Empleado empleado = JsonConvert.DeserializeObject<Empleado>(jsonempleado);
            return empleado;
        }
    }
}
