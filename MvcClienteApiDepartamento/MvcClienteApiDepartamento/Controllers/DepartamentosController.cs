using Microsoft.AspNetCore.Mvc;
using MvcClienteApiDepartamento.Models;
using MvcClienteApiDepartamento.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudDepartamentos.Controllers
{
    public class DepartamentosController : Controller
    {
        ServiceDepartamentos serviceapi;
        
        public DepartamentosController(ServiceDepartamentos serviceapi)
        {
            this.serviceapi = serviceapi;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListDepartamentos()
        {
            return View(await this.serviceapi.GetDepartamentosAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.serviceapi.BuscarDepartamentoAsync(id));

        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(await this.serviceapi.BuscarDepartamentoAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento dept)
        {
            int id = dept.IdDepartamento;
            await this.serviceapi.ModificarDepartamentoAsync(id, dept.Nombre, dept.Localidad);
            return RedirectToAction("ListDepartamentos");
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento dept)
        {
            await this.serviceapi.InsertarDepartamentoAsync(dept.IdDepartamento, dept.Nombre, dept.Localidad);
            return RedirectToAction("ListDepartamentos");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await this.serviceapi.EliminarDepartamentoAsync(id);
            return RedirectToAction("ListDepartamentos");
        }

        public IActionResult ApiClienteAjax()
        {
            return View();
        }

        public IActionResult ApiCrudServidor()
        {
            return View();
        }
    }
}
