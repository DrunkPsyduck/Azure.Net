﻿using ApiEmpleadoOAuth.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcClienteApiEmpleado.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcClienteApiEmpleado.Controllers
{
    public class IdentityController : Controller
    {
        ServiceEmpleados ApiService;

        public IdentityController(ServiceEmpleados apiservice)
        {
            this.ApiService = apiservice;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(String username, String password)
        {
            String token = await this.ApiService.GetToken(username, password);
            if (token == null)
            {
                ViewData["MENSAJE"] = "Las credenciales no son correctas";
                return View();
            }
            else
            {
                Empleado empleado = await this.ApiService.GetPerfil(token);
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, empleado.IdEmpleado.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, empleado.Apellido));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddMinutes(15)
                });

                //almacenar el token para trabajar
                HttpContext.Session.SetString("TOKEN", token);
                return RedirectToAction("PerfilEmpleado", "Empleados");
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            if (HttpContext.Session.GetString("TOKEN") != null)
            {
                HttpContext.Session.Remove("TOKEN");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
