using Microsoft.AspNetCore.Mvc;
using MvcClienteApiDepartamento.Services;
using NugetDoctorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApiDepartamento.Controllers
{
    public class DoctorController : Controller
    {
        ServiceDoctores serviceApi;
        public DoctorController(ServiceDoctores serviceApi)
        {
            this.serviceApi = serviceApi;
        }

      

        public async Task<IActionResult> Index() { 
            return View(await this.serviceApi.GetDoctoresAsync()); 
        }
        [HttpPost]
        public async Task<IActionResult> Index(int incremento, int hospital)
        {
            await this.serviceApi.IncrementarSalariosAsync(incremento, hospital);
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await this.serviceApi.GetDoctorAsync(id));
        }

        public async Task<IActionResult> Edit(int id) {
            return View(await this.serviceApi.GetDoctorAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            await this.serviceApi.UpdateDoctorAsync(doctor.IdDoctor, doctor.Apellido, doctor.Especialidad, doctor.Hospital, doctor.Salario);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            await this.serviceApi.InsertarDoctorAsync(doctor.IdDoctor, doctor.Apellido, doctor.Especialidad, doctor.Hospital, doctor.Salario);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.serviceApi.DeleteDoctorAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public List<String> Especialidades()
        {
            
        }
    }
}
