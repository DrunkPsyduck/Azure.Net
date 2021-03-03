using Microsoft.AspNetCore.Mvc;
using MvcCoreDoctores.Models;
using MvcCoreDoctores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDoctores.Controllers
{
    public class DoctoresController : Controller
    {
        ServiceApiDoctores service;

        public DoctoresController(ServiceApiDoctores service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DoctoresCliente()
        {
            return View();
        }

        public async Task<IActionResult> DoctoresServidor()
        {
            List<Doctor> doctores = await this.service.GetDoctoresAsync();
            List<String> especialidades = await this.service.GetEspecialidadesAsync();
            ViewData["ESPECIALIDADES"] = especialidades;
            return View(doctores);
        }

        public async Task<IActionResult> DetallesServidor(int id)
        {
            Doctor doctor = await this.service.BuscarDoctor(id);

            return View(doctor);
        }
    }
}
