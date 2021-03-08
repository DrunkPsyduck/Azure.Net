using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcClienteApiEmpleado.Filters;
using MvcClienteApiEmpleado.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApiEmpleado.Controllers
{
    public class EmpleadosController : Controller
    {
        ServiceEmpleados ApiService;

        public EmpleadosController(ServiceEmpleados ApiService)
        {
            this.ApiService = ApiService;
        }

        [EmpleadoAuthorize]
        public async Task<IActionResult> PerfilEmpleado()
        {
            String token = HttpContext.Session.GetString("TOKEN");
            return View(await this.ApiService.GetPerfil(token));
        }

        [EmpleadoAuthorize]
        public async Task<IActionResult> Subordinados()
        {
            String token = HttpContext.Session.GetString("TOKEN");
            return View(await this.ApiService.GetSubordinados(token));
        }


    }
}
