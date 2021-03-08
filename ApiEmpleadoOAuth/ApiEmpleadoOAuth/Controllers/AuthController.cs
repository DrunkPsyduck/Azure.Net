using ApiEmpleadoOAuth.Helpers;
using ApiEmpleadoOAuth.Models;
using ApiEmpleadoOAuth.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiEmpleadoOAuth.Controllers
{
    //Validacion directa desde controller
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        RepositoryEmpleados repo;
        HelperToken helperToken;

        public AuthController(RepositoryEmpleados repo, HelperToken helperToken)
        {
            this.repo = repo;
            this.helperToken = helperToken;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginModel model)
        {
            Empleado empleado = this.repo.ExisteEmpleado(model.UserName, int.Parse(model.Password));
            if (empleado == null)
            {
                return Unauthorized();
            }
            else
            {
                //El usuario o que queramos se almacena dentro del tokem mediante Claim. Claim permite almacenar datos por Key, Value
                String empleadojson = JsonConvert.SerializeObject(empleado);
                Claim[] claims = new[]
                {
                    new Claim("UserData", empleadojson)
                };

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: this.helperToken.Issuer,
                    audience: this.helperToken.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(this.helperToken.GetKeyToken(), SecurityAlgorithms.HmacSha256));

                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                }); 
            }
        }
    }
}
