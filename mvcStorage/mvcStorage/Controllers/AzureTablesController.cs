using Microsoft.AspNetCore.Mvc;
using mvcStorage.Models;
using mvcStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Controllers
{
    public class AzureTablesController : Controller
    {
        ServiceStorageTables serviceTables;
        public AzureTablesController(ServiceStorageTables service)
        {
            this.serviceTables = service;
        }
        public async Task<IActionResult> Index()
        {
            List<String> empresas = await this.serviceTables.GetEmpresasAsync();
            ViewData["EMPRESAS"] = empresas;
            return View(await this.serviceTables.GetClienteAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(String empresa)
        {
            ViewData["EMPRESAS"] = await this.serviceTables.GetEmpresasAsync();
            return View(await this.serviceTables.GetClientesEmpresaAsync(empresa));
        }

        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Cliente cliente)
        {
            await this.serviceTables.CreateClientAsync(cliente.IdCliente, cliente.Nombre, cliente.Edad, cliente.Empresa);
            return RedirectToAction("Index");
        }
    }
}
