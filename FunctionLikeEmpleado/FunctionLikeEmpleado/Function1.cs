using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionLikeEmpleado
{
    public static class Function1
    {
        [FunctionName("FunctionLikeEmp")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("App para dar like a empleados");

            string empno = req.Query["empno"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            empno = empno ?? data?.name;

            if(empno == null)
            {
                return new BadRequestObjectResult("Necesitamos el parametro de {empno}");
            }

            String cadenaconexion = @"Data Source=localhost;Initial Catalog=Hospitales;User ID=sa:Password=MCSD2020";

            return new OkObjectResult("");
        }
    }
}
