using Microsoft.AspNetCore.Mvc;
using mvcStorage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcStorage.Controllers
{
    public class QueueController : Controller
    {
        ServiceQueueBus ServiceBus;

        public QueueController(ServiceQueueBus servicequeue)
        {
            this.ServiceBus = servicequeue;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index (String mensaje, String accion)
        {
            List<String> mensajes;
            if(accion.ToLower() == "mensaje")
            {
                await this.ServiceBus.SendMessage(mensaje);
            } else if (accion.ToLower() == "batch")
            {
                await this.ServiceBus.SendBatchMenssages();
            } else if(accion.ToLower() == "recibir")
            {
               
                 mensajes = await this.ServiceBus.RecibirMensajes();
               
                return View(mensajes);
            }
            return View();
        }
    }
}
