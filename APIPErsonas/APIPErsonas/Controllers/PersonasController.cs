using APIPErsonas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPErsonas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        List<Persona> personas;

        public PersonasController()
        {
            personas = new List<Persona>
            {
                new Persona { IdPersona=1,Nombre="Mario",Edad=25 },
                new Persona {IdPersona=2, Nombre="Bunta Fujiwara", Edad=50},
                new Persona {IdPersona=3,Nombre="Sabinita", Edad=23}
            };
        }

        [HttpGet]
        public ActionResult<List<Persona>> Get()
        {
            return this.personas;
        }

        [HttpGet("{id}")]
        public ActionResult<Persona> GetPersona(int id)
        {
            return this.personas.SingleOrDefault(x=> x.IdPersona == id);
        }
    }
}
