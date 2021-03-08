using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcClienteApiEmpleado.Filters
{
    public class EmpleadoAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Empleado validado?
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                RouteValueDictionary rutalogin = new RouteValueDictionary(new
                {
                    controller = "Identity",
                    action = "Login"
                });
                context.Result = new RedirectToRouteResult(rutalogin);
            }
        }
    }
}
