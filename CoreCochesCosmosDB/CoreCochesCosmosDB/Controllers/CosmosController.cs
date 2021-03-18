using CoreCochesCosmosDB.Models;
using CoreCochesCosmosDB.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCochesCosmosDB.Controllers
{
    public class CosmosController : Controller
    {
        ServiceCosmosDB servicecosmos;
        public CosmosController(ServiceCosmosDB service)
        {
            this.servicecosmos = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(String accion)
        {
            ViewData["MENSAJE"] = "Iniciando";
            await this.servicecosmos.CrearBbddVEhiculosAsync();
            await this.servicecosmos.CrearColeccionVehiculosAsync();
            List<Vehiculo> coches = this.servicecosmos.CrearCoches();

            foreach(Vehiculo car in coches)
            {
                await this.servicecosmos.InsertarVehiculo(car);
            }

            ViewData["MENSAJE"] = "Todo iniciado";
            return View();
        }

        public IActionResult ListCoches()
        {
            return View(this.servicecosmos.GetVehiculos());
        }

        public async Task<IActionResult> Details(string id)
        {
            return View(await this.servicecosmos.FindVehiculoAsync(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehiculo car, String motor) {
            if (motor != null)
            {
                car.Motor = new Motor { Tipo = "BR2J", Caballos = 320, Potencia = 320 };
            }

            await this.servicecosmos.InsertarVehiculo(car);
            return RedirectToAction("ListCoches");
        }

        public async Task<IActionResult> Delete(String id)
        {
            await this.servicecosmos.EliminarVehiculo(id);
            return RedirectToAction("ListCoches");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Vehiculo car, String motor)
        {
            if (motor != null)
            {
                car.Motor = new Motor { Tipo = "4age", Caballos = 150, Potencia = 150 };
            }

            await this.servicecosmos.ModificarVehiculo(car);
            return RedirectToAction("ListCoches");
        }
    }
}
