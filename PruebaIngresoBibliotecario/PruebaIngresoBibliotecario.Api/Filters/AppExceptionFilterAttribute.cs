using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PruebaIngresoBibliotecario.Domain.Exceptions;
using System.Net;

namespace PruebaIngresoBibliotecario.Api.Filters
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (context.Exception is DomainException domainException)
            {
                context.HttpContext.Response.StatusCode = domainException.HttpStatusCode;
                context.Result = new ObjectResult(new { Mensaje = context.Exception.Message });
            }          
        }
    }
}
