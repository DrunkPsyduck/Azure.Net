using Microsoft.AspNetCore.Mvc;
using mvcStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Controllers
{
    public class AlumnosController : Controller
    {
        ServiceTableAlumno ServiceAlumnos;

        public AlumnosController(ServiceTableAlumno serviceAlumnos)
        {
            this.ServiceAlumnos = serviceAlumnos;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(String curso)
        {
            String token = await this.ServiceAlumnos.GetTokenAsync(curso);
            return View(this.ServiceAlumnos.GetAlumnos(token));
        }
    }
}
